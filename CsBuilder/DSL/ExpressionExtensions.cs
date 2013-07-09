using CsBuilder.Expressions;
using CsBuilder.Types;
using System;

namespace CsBuilder.DSL
{
    public static class ExpressionExtensions
    {
        public static MethodCallExpression Call(this Expression expression, string name)
        {
            return new MethodCallExpression(name, expression);
        }

        public static CastExpression CastTo(this Expression expression, string customType)
        {
            return CastTo(expression, new CustomType(customType));
        }

        public static CastExpression CastTo(this Expression expression, CsType type)
        {
            return new CastExpression(expression, type);
        }
        
        public static ConditionalExpression<Expression> If(this Expression expression, bool condition) 
        {
            return new ConditionalExpression<Expression>(condition, expression);
        }
 
        public static Expression ThenChain(this ConditionalExpression<Expression> conditionalExpression, Func<Expression, Expression> func) 
        {
            conditionalExpression.ConditionedExpression = func;
            return conditionalExpression.Expression;
        }

        public static Expression Coalesce(this Expression leftExpression, Expression rightExpression)
        {
            return new CoalesceExpression(leftExpression, rightExpression);
        }
    }
}