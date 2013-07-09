using System;
using CsBuilder.Expressions;
using CsBuilder.Statements;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class IAttributableExtensions
    {
        public static T WithAttribute<T>(this T attributable, string typeName, params Expression[] parameters) where T : IAttributable
        {
            return WithAttribute(attributable, typeName.AsType(), parameters);
        }

        public static T WithAttribute<T>(this T attributable, CsType type, params Expression[] parameters) where T : IAttributable
        {
            var attributeStatement = new AttributeStatement(type);
            if (parameters != null)
            {
                foreach (Expression expression in parameters)
                {
                    attributeStatement.AddParam(expression);
                }
            }

            attributable.AddAttribute(attributeStatement);
            return attributable;
        }

        public static ConditionalExpression<PropertyStatement> If(this PropertyStatement statement, bool condition)
        {
            return new ConditionalExpression<PropertyStatement>(condition, statement);
        }

        public static PropertyStatement ThenChain(this ConditionalExpression<PropertyStatement> conditionalStatement, Func<PropertyStatement, PropertyStatement> func)
        {
            conditionalStatement.ConditionedExpression = func;
            return conditionalStatement.Expression;
        }
    }
}