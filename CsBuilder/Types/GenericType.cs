#region [ using ]

using System.Collections.Generic;
using System.Linq;
using CsBuilder.Formatters;
using CsBuilder.Utils;

#endregion

namespace CsBuilder.Types
{
    public class GenericType : CsType
    {
        public GenericType(string name, params CsType[] genericArgumentTypes)
            : base(name)
        {
            GenericArgumentTypes = genericArgumentTypes;
        }

        public IEnumerable<CsType> GenericArgumentTypes { get; protected set; }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write("{0}<", name);

            string placeholders = CodeUtils.Placeholders(GenericArgumentTypes.Count());
            renderer.Write(string.Format("{0}>", placeholders), GenericArgumentTypes.ToArray());
        }
    }
}