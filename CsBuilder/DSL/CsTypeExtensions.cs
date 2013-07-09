using CsBuilder.Expressions;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class CsTypeExtensions
    {
        public static NewExpression New(this CsType type)
        {
            var complexType = type as IComplexType;
            if (complexType != null)
                return New(complexType);

            return new NewExpression(type);
        }

        public static NewExpression New(this IComplexType complexType)
        {
            return new NewExpression(complexType.ImplementationType);
        }

        public static MethodCallExpression Call(this CsType type, string name)
        {
            return new MethodCallExpression(name, type);
        }
    }
}