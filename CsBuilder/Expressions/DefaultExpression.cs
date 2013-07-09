using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Types;

namespace CsBuilder.Expressions
{
    public class DefaultExpression : Expression
    {
        private const string snippet = "default({0})";
        private readonly CsType type;

        public DefaultExpression(CsType type)
        {
            this.type = type;
        }
        
        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, type);
        }
    }
}
