#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class SemicolonStatement : Statement
    {
        private const string snippet = "{0};";
        private readonly ICode code;

        public SemicolonStatement()
        {
        }

        public SemicolonStatement(ICode code)
        {
            this.code = code;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, code);
        }
    }
}