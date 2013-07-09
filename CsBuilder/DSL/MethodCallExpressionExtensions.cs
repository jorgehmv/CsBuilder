using System.Linq;
using CsBuilder.Expressions;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class MethodCallExpressionExtensions
    {
        public static MethodCallExpression Of(this MethodCallExpression methodCallExpression,
                                                  params CsType[] argumentTypes)
        {
            foreach (var argumentType in argumentTypes)
            {
                methodCallExpression.AddGenericArgument(argumentType);
            }

            return methodCallExpression;
        }

        public static MethodCallExpression Of(this MethodCallExpression methodCallExpression,
                                                  params string[] argumentTypeNames)
        {
            return Of(methodCallExpression, argumentTypeNames.Select(at => at.AsType()).ToArray());
        }

        public static MethodCallExpression RefParam(this MethodCallExpression methodCallExpression, Expression refParam)
        {
            methodCallExpression.AddParam(new RefExpression(refParam));
            
            return methodCallExpression;
        }

        public static MethodCallExpression Params(this MethodCallExpression methodCallExpression,
                                                  params Expression[] parameters)
        {
            foreach (Expression parameter in parameters)
            {
                methodCallExpression.AddParam(parameter);
            }

            return methodCallExpression;
        }
    }
}