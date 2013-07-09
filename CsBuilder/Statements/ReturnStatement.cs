#region [ using ]

using CsBuilder.Expressions;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class ReturnStatement : Statement
    {
        private readonly Expression expression;
        protected string snippet = "return {0};";

        public ReturnStatement(Expression expression)
        {
            this.expression = expression;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, expression);
        }
    }
}