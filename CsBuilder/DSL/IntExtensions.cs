using CsBuilder.Expressions;

namespace CsBuilder.DSL
{
    public static class IntExtensions
    {
        public static Expression Value(this int value)
        {
            return new ConstantExpression(value.ToString());
        }
    }
}