using CsBuilder.Expressions;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class StringExtensions
    {
        public static Expression Value(this string value)
        {
            return new ConstantExpression(string.Format(@"@""{0}""", value));
        }

        public static CsType AsType(this string typeName)
        {
            return new CustomType(typeName);
        }
    }
}