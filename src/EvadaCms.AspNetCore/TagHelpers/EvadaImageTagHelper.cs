using Evada.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evada.AspNetCore.TagHelpers
{
    public class EvadaImageTagHelper : TagHelper
    {
        public IEvadaClient _evadaClient;
        public Asset Asset { get; set; }
        public string Language { get; set; }
        public string Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string BackgroundColor { get; set; }

        protected readonly List<KeyValuePair<string, string>> _queryKeyPairs = new List<KeyValuePair<string, string>>();

        public EvadaImageTagHelper(IEvadaClient evadaClient)
        {
            _evadaClient = evadaClient;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await output.GetChildContentAsync();

            output.TagName = "img";
            output.Attributes.Add("src", BuildUrl());

            if (!context.AllAttributes.ContainsName("alt")
                && !string.IsNullOrEmpty(Language)
                && Asset.Metadata.TryGetValue(Language, out AssetMetadata metadataDescription))
            {
                output.Attributes.Add("alt", metadataDescription.Description);
            }

            if (!context.AllAttributes.ContainsName("title")
                && !string.IsNullOrEmpty(Language)
                && Asset.Metadata.TryGetValue(Language, out AssetMetadata metadataTitle))
            {
                output.Attributes.Add("title", metadataTitle.Title);
            }
        }

        public string BuildUrl(bool includeEmptyParameters = false)
        {
            if (Asset != null)
            {
                Url = Asset.Location;
            }

            if (Width > 0)
            {
                _queryKeyPairs.Add(new KeyValuePair<string, string>("width", Width.ToString()));
            }

            if (Height > 0)
            {
                _queryKeyPairs.Add(new KeyValuePair<string, string>("height", Height.ToString()));
            }

            var queryString = _queryKeyPairs
                .Aggregate(new StringBuilder(), (sb, kvp) =>
                {
                    if (kvp.Value != null)
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        sb.AppendFormat("{0}={1}", Uri.EscapeUriString(kvp.Key),
                            Uri.EscapeDataString(kvp.Value));
                    }
                    else if (includeEmptyParameters)
                    {
                        if (sb.Length > 0)
                            sb = sb.Append("&");

                        sb.AppendFormat("{0}", Uri.EscapeUriString(kvp.Key));
                    }

                    return sb;
                }).ToString();

            return $"{Url}?{queryString}";
        }
    }
}
