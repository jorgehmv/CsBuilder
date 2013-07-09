#region [ using ]

using System.Collections.Generic;
using System.Linq;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class BracedCode : ICode
    {
        private readonly IList<ICode> codes;

        public BracedCode()
            : this(new List<ICode>())
        {
        }

        public BracedCode(IEnumerable<ICode> code)
        {
            codes = code.ToList();
        }

        public bool SingleLine { get; set; }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            if (!SingleLine)
            {
                renderer.WriteLine("");
                renderer.WriteLine("{");
                renderer.PushIndent();

                foreach (ICode codeLine in codes)
                {
                    renderer.WriteLine("{0}", codeLine);
                }

                renderer.PopIndent();
                renderer.WriteLine("}");
            }
            else
            {
                renderer.Write("{ ");

                foreach (ICode codeLine in codes)
                {
                    renderer.Write("{0}", codeLine);
                }

                renderer.Write(" }");
            }
        }

        #endregion

        public void AddCode(ICode code)
        {
            codes.Add(code);
        }

        public bool HasCode()
        {
            return codes.Count > 0;
        }
    }
}