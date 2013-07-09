#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Expressions
{
    public class ConstantExpression : Expression
    {
        private readonly string expression;

        public ConstantExpression(string expression)
        {
            this.expression = expression;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(expression);
        }
    }
}