#region [ using ]

using CsBuilder.Expressions;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class InitDeclarationStatement : Statement
    {
        private const string snippet = "{0} = {1}";
        private readonly DeclarationStatement declaration;
        private readonly Expression value;

        public InitDeclarationStatement(DeclarationStatement declaration, Expression value)
        {
            this.declaration = declaration;
            this.value = value;
        }

        public override void Render(ICodeWriter codeRenderer)
        {
            codeRenderer.Write(snippet, declaration, value);
        }
    }
}