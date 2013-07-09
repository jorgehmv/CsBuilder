#region [ using ]

using CsBuilder.Elements;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class NamespaceStatement : Statement
    {
        private const string snippet = "namespace {0}{1}";
        private readonly BracedCode bracedCode;
        private readonly NameElement name;

        public NamespaceStatement(string name, ICode code)
        {
            this.name = new NameElement(name);
            bracedCode = new BracedCode(new[] {code});
        }

        public override void Render(ICodeWriter codeRenderer)
        {
            codeRenderer.Write(snippet, name, bracedCode);
        }
    }
}