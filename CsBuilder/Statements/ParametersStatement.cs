#region [ using ]

using System.Collections.Generic;
using System.Linq;
using CsBuilder.Formatters;
using CsBuilder.Utils;

#endregion

namespace CsBuilder.Statements
{
    public class ParameterListStatement : Statement
    {
        private readonly IList<DeclarationStatement> declarations;

        public ParameterListStatement()
            : this(Enumerable.Empty<DeclarationStatement>())
        {
        }

        public ParameterListStatement(IEnumerable<DeclarationStatement> declarations)
        {
            this.declarations = declarations.ToList();
        }

        public void AddParam(DeclarationStatement declaration)
        {
            declarations.Add(declaration);
        }

        public override void Render(ICodeWriter codeRenderer)
        {
            codeRenderer.Write(CodeUtils.Placeholders(declarations.Count), declarations.ToArray());
        }
    }
}