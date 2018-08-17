using System;

namespace Evada.Core.QueryParameters
{
    public class TypeParameter : QueryParameter
    {
        public Guid TypeId { get; set; }

        public TypeParameter(Guid typeId)
        {
            TypeId = typeId;
        }

        public override string Name { get; } = "system.type.id";

        public override string Value
        {
            get
            {
                return TypeId.ToString();
            }
        }
    }
}