#region [ using ]

using CsBuilder.Formatters;
using CsBuilder.Operators;

#endregion

namespace CsBuilder.Expressions
{
    public class AndCondition : Expression
    {
        private const string snippet = "({0} {1} {2})";
        private readonly Expression left;
        private readonly Expression right;

        public AndCondition(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Render(ICodeWriter renderer)
        {
            if (left.IsBool && right.IsBool)
            {
                renderer.Write(snippet, left, ConditionalOperator.And, right);
            }
            else
            {
                renderer.Write(snippet, left, BinaryOperator.And, right);
            }
        }
    }

    public class OrCondition : Expression
    {
        private const string snippet = "({0} {1} {2})";
        private readonly Expression left;
        private readonly Expression right;

        public OrCondition(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Render(ICodeWriter renderer)
        {
            if (left.IsBool && right.IsBool)
            {
                renderer.Write(snippet, left, ConditionalOperator.Or, right);
            }
            else
            {
                renderer.Write(snippet, left, BinaryOperator.Or, right);
            }
        }
    }

    public class NotCondition : Expression
    {
        private const string snippet = "{0}{1}";
        private readonly Expression expression;

        public NotCondition(Expression expression)
        {
            this.expression = expression;
        }

        public override void Render(ICodeWriter renderer)
        {
            if (expression.IsBool)
            {
                renderer.Write(snippet, ConditionalOperator.Not, expression);
            }
            else
            {
                renderer.Write(snippet, BinaryOperator.Not, expression);
            }
        }
    }
}