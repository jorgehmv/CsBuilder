#region [ using ]

using CsBuilder.Expressions;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class WhileStatement : Statement
    {
        private const string snippet = "while({0}){1}";
        private readonly BlockStatement body;
        private readonly Expression expression;

        public WhileStatement(Expression expression, BlockStatement body)
        {
            this.expression = expression;
            this.body = body;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, expression, body);
        }
    }
}