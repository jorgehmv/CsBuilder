#region [ using ]

using CsBuilder.Expressions;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class IfStatement : Statement
    {
        private const string snippet = "if({0}){1}";
        private readonly BlockStatement body;
        private readonly Expression expression;

        public IfStatement(Expression expression, BlockStatement body)
        {
            this.expression = expression;
            this.body = body;
        }

        public override void Render(ICodeWriter codeRenderer)
        {
            codeRenderer.Write(snippet, expression, body);
        }
    }
}