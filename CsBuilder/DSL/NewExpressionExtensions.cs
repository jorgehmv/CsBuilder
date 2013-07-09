using CsBuilder.Expressions;

namespace CsBuilder.DSL
{
    public static class NewExpressionExtensions
    {
        public static NewExpression Init(this NewExpression newExpression, params Expression[] values)
        {
            var memberInitializer = new CollectionMemberInitializerExpression();
            foreach (var expression in values)
            {
                memberInitializer.AddValue(expression);
            }
            newExpression.AddMemberInitializer(memberInitializer);

            return newExpression;
        }

        public static NewExpression Params(this NewExpression newExpression,
                                                  params Expression[] parameters)
        {
            foreach (Expression parameter in parameters)
            {
                newExpression.AddParam(parameter);
            }

            return newExpression;
        }
    }
}