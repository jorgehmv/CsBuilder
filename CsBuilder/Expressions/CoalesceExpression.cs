using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;

namespace CsBuilder.Expressions
{
    public class CoalesceExpression : Expression
    {
        private const string snippet = "({0} ?? {1})";
        private readonly Expression leftExpression;
        private readonly Expression rightExpression;

        public CoalesceExpression(Expression leftExpression, Expression rightExpression)
        {
            this.leftExpression = leftExpression;
            this.rightExpression = rightExpression;
        }
        
        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, leftExpression, rightExpression);
        }
    }
}
