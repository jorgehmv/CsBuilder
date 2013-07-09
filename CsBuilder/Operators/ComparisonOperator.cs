#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Operators
{
    public class ComparisonOperator : ICode
    {
        public static readonly ComparisonOperator Equality = new ComparisonOperator("==");
        public static readonly ComparisonOperator LessThan = new ComparisonOperator("<");
        public static readonly ComparisonOperator LessThanOrEqualsTo = new ComparisonOperator("<=");
        public static readonly ComparisonOperator GreaterThan = new ComparisonOperator(">");
        public static readonly ComparisonOperator GreaterThanOrEqualsTo = new ComparisonOperator(">=");
        public static readonly ComparisonOperator Inequality = new ComparisonOperator("!=");

        private readonly string operatorString;

        private ComparisonOperator(string operatorString)
        {
            this.operatorString = operatorString;
        }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            renderer.Write(operatorString);
        }

        #endregion
    }
}