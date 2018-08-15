using Evada.DeliveryApi;
using Evada.DeliveryApi.Models;
using Evada.Core.QueryParameters;
using Evada.ManagementApi;
using Evada.ManagementApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleWorkbench
{
    class Program
    {
        const string _baseUrl = "https://localhost:49965";
        const string _containerId = "be140d2b-267f-4ba5-9b60-dc8ebcb5446c";

        static void Main(string[] args)
        {
            // ManagementApiMainAsync(args).GetAwaiter().GetResult();

            // Containers_GetAll().GetAwaiter().GetResult();
            // Containers_Get().GetAwaiter().GetResult();
            // Containers_Create().GetAwaiter().GetResult();
            // Containers_Update().GetAwaiter().GetResult();

            // ContentItems_GetAll().GetAwaiter().GetResult();
            // ContentItems_Get().GetAwaiter().GetResult();

            //ContentItems_TPF().GetAwaiter().GetResult();
            //ContentItems_TPF_HomePage().GetAwaiter().GetResult();
            //ContentItems_Via_Home().GetAwaiter().GetResult();
            // ContentItems_Serialized().GetAwaiter().GetResult();

            //Items_GetAll_No_Params().GetAwaiter().GetResult();
            //Items_GetAll_ByCreatedAt().GetAwaiter().GetResult();
            //Items_GetAll_By_Name().GetAwaiter().GetResult();
            //Items_GetAll_By_Slug().GetAwaiter().GetResult();
            //Items_GetAll_By_PublishAt().GetAwaiter().GetResult();
            //Items_GetAll_With_Select().GetAwaiter().GetResult();
            Items_GetAll_With_OrderBy().GetAwaiter().GetResult();
            //Items_GetAll_ByLang().GetAwaiter().GetResult();
            //Items_GetAll_ByTypeId().GetAwaiter().GetResult();
            //Items_GetSingle().GetAwaiter().GetResult();

            Console.ReadKey();
        }

        public static async Task Items_GetAll_With_OrderBy()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new SelectParameter(new List<string>
                    {
                        Fields.Name
                    }),
                    new OrderParameter(Fields.Name, descending: true),
                    new TotalParameter(true)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }

            Console.WriteLine(items.Pagination.Total);
        }

        public static async Task Items_GetAll_With_Select()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new SelectParameter(new List<string>
                    {
                        Fields.Name
                    })
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_By_PublishAt()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new FirstPublishedAtParameter(ParameterOperator.LessThan, DateTime.Parse("8/6/2018")),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_By_Slug()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new SlugParameter(ParameterOperator.Equals, "different_type_test"),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_By_Name()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new NameParameter(ParameterOperator.Equals, "Different Type Test"),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_ByCreatedAt()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new CreatedAtParameter(ParameterOperator.LessThan, DateTime.Parse("8/6/2018")),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetSingle()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var item = await client.Items.GetSingleAsync("test_item_for_publishing",
                new List<IQueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new DepthParameter(1)
                });
            Console.WriteLine(item.System.Name);
        }

        public static async Task Items_GetAll_ByLang()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_ByTypeId()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);
            var items = await client.Items.GetAsync(
                new List<IQueryParameter>
                {
                    new TypeParameter(Guid.Parse("6ffdeb1b-9b87-4154-a5b0-65c362970906")),
                    new DepthParameter(1)
                });

            foreach (var item in items.Items)
            {
                Console.WriteLine(item.System.Name);
            }
        }

        public static async Task Items_GetAll_No_Params()
        {
            var client = new DeliveryApiClient(_containerId, _baseUrl);

            /*foreach (var item in await client.Items.GetAllAsync())
            {
                Console.WriteLine(item.System.Name);
            }*/
            var items = await client.Items.GetAsync();
            var item = items.Items[0];
            //Console.WriteLine(item.GetString("title"));
            Console.WriteLine(item.GetValue<string>("title"));
            /*foreach (var module in item.Modules)
            {
                Console.WriteLine(module.Value.Value);
            }*/
        }

        /*public static async Task ContentItems_Get()
        {
            var contentApiClient = new ContentApiClient("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b", _token, _baseUrl);
            
            var item = await contentApiClient.ContentItems.GetAsync("eric-zimmerman",
                new List<IQueryParameter>
                {
                    new LanguageParameter("en-US"),
                    new DepthParameter(1),
                    new ExcludeModulesParameter(false)
                });
            //var modules = ((IEnumerable<dynamic>)item.modules);

            //foreach (var module in modules)
            //{
            //    Console.WriteLine(module.value);
            //}

            //Console.WriteLine(item.name);
        }*/

        /*public static async Task ContentItems_Serialized()
        {
            var contentApiClient = new ContentApiClient("e28f16bb-7cde-4c84-bfeb-f9ed7f450f9b");
            ContentItem item = await contentApiClient.ContentItems.GetAsync("eric-zimmermans", 
                new List<IQueryParameter>
                {
                    new DepthParameter(1)
                });

            var nameModule = item.Modules.FirstOrDefault(x => x.Slug == "name");
            Console.WriteLine(nameModule.Value);
            //foreach (var module in item.Modules)
            //{
            //    Console.WriteLine(module.Value);
            //}
        }*/

        /*public static async Task ContentItems_TPF_HomePage()
        {
            var contentApiClient = new ContentApiClient("729e5a36-798d-4006-8dfe-397c26d6db2d", string.Empty, _baseUrl);

            ContentItem item = await contentApiClient.ContentItems.GetAsync("home-page");
            var assets = item.GetAssets("banner-image");

            List<ContentItem> showItems = await contentApiClient.ContentItems.GetAllAsync(new List<IQueryParameter>
            {
                new TypesParameter("show"),
                new DepthParameter(1)
            });

            foreach (var show in showItems)
            {
                var venue = show.GetReferenceItems("venue").FirstOrDefault();
                if (venue != null)
                {
                    Console.WriteLine(venue.GetString("name"));
                }
            }
        }*/

        /*public static async Task ContentItems_TPF()
        {
            var contentApiClient = new ContentApiClient("729e5a36-798d-4006-8dfe-397c26d6db2d", string.Empty, _baseUrl);

            //ContentItem item = await contentApiClient.ContentItems.GetAsync("home-page");
            List<ContentItem> showItems = await contentApiClient.ContentItems.GetAllAsync(new List<IQueryParameter>
            {
                new TypesParameter("show"),
                new DepthParameter(1)
            });

            foreach (var show in showItems)
            {
                var venue = show.GetReferenceItems("venue").FirstOrDefault();
                if (venue != null)
                {
                    Console.WriteLine(venue.GetString("name"));
                }
            }
        }*/
    }
}
