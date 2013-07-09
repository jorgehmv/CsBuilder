#region [ using ]

using System.Linq;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Types
{
    public class NullableType : GenericType
    {
        private const string snippet = "{0}?";

        public CsType GenericArgumentType { get; set; }

        public NullableType(CsType genericArgumentType)
            : base("Nullable", genericArgumentType)
        {
            GenericArgumentType = genericArgumentType;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, GenericArgumentType);
        }
    }
}