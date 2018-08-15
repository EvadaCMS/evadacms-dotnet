using System;

namespace Evada.Core.QueryParameters
{
    public class TypeParameter : IQueryParameter
    {
        public Guid TypeId { get; set; }

        public TypeParameter(Guid typeId)
        {
            TypeId = typeId;
        }

        public string Name { get; } = "system.type.id";

        public string Value
        {
            get
            {
                return TypeId.ToString();
            }
        }
    }
}