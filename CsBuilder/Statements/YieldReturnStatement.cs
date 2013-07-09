using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Expressions;
using CsBuilder.Formatters;

namespace CsBuilder.Statements
{
    public class YieldReturnStatement : Statement
    {
        private readonly Expression expression;
        protected string snippet = "yield return {0};";

        public YieldReturnStatement(Expression expression)
        {
            this.expression = expression;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, expression);
        }
    }
}
