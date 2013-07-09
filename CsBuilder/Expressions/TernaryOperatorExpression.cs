#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Expressions
{
    public class TernaryOperatorExpression : Expression
    {
        private const string snippet = "({0} ? {1} : {2})";

        public TernaryOperatorExpression()
            : this(True, True, False)
        {
        }

        public TernaryOperatorExpression(Expression condition, Expression trueExpression, Expression falseExpression)
        {
            Condition = condition;
            TrueExpression = trueExpression;
            FalseExpression = falseExpression;
        }

        public Expression Condition { get; set; }
        public Expression TrueExpression { get; set; }
        public Expression FalseExpression { get; set; }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, Condition, TrueExpression, FalseExpression);
        }
    }
}