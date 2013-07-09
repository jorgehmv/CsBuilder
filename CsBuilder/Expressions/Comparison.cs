#region [ using ]

using CsBuilder.Formatters;
using CsBuilder.Operators;

#endregion

namespace CsBuilder.Expressions
{
    public abstract class Comparison : Expression
    {
        private const string snippet = "({0} {1} {2})";
        private readonly Expression left;
        private readonly Expression right;

        protected ComparisonOperator comparisonOperator;

        protected Comparison(Expression left, ComparisonOperator comparisonOperator, Expression right)
        {
            this.left = !ReferenceEquals(left, null) ? left : Null;
            this.comparisonOperator = comparisonOperator;
            this.right = !ReferenceEquals(right, null) ? right : Null;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, left, comparisonOperator, right);
        }
    }

    public class EqualityComparison : Comparison
    {
        public EqualityComparison(Expression left, Expression right)
            : base(left, ComparisonOperator.Equality, right)
        {
        }
    }

    public class GreaterThanComparison : Comparison
    {
        public GreaterThanComparison(Expression left, Expression right)
            : base(left, ComparisonOperator.GreaterThan, right)
        {
        }
    }

    public class GreaterThanOrEqualsToComparison : Comparison
    {
        public GreaterThanOrEqualsToComparison(Expression left, Expression right)
            : base(left, ComparisonOperator.GreaterThanOrEqualsTo, right)
        {
        }
    }

    public class LessThanComparison : Comparison
    {
        public LessThanComparison(Expression left, Expression right)
            : base(left, ComparisonOperator.LessThan, right)
        {
        }
    }

    public class LessThanOrEqualsToComparison : Comparison
    {
        public LessThanOrEqualsToComparison(Expression left, Expression right)
            : base(left, ComparisonOperator.LessThanOrEqualsTo, right)
        {
        }
    }

    public class InequalityComparison : Comparison
    {
        public InequalityComparison(Expression left, Expression right)
            : base(left, ComparisonOperator.Inequality, right)
        {
        }
    }
}