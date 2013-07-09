using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Expressions;

namespace CsBuilder.DSL
{
    public class ConditionalExpression<T> : ICode where T : ICode
    {
        private readonly bool condition;

        public T OriginalExpression { get; protected set; }
        public Func<T, T> ConditionedExpression { get; set; }

        public ConditionalExpression(bool condition, T originalCode)
        {
            this.condition = condition;
            OriginalExpression = originalCode;
            ConditionedExpression = c => originalCode;
        }

        public T Expression
        {
            get { return condition ? ConditionedExpression(OriginalExpression) : OriginalExpression; }
        }

        public void Render(ICodeWriter renderer)
        {
            Expression.Render(renderer);
        }
    }
}
