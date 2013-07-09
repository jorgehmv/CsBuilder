using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;

namespace CsBuilder.Expressions
{
    public class RefExpression : Expression
    {
        private const string snippet = "ref {0}";
        private readonly Expression expression;

        public RefExpression(Expression expression)
        {
            this.expression = expression;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, expression);
        }
    }
}
