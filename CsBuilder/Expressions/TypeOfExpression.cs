using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Types;

namespace CsBuilder.Expressions
{
    public class TypeOfExpression : Expression
    {
        private const string snippet = "typeof({0})";
        private readonly CsType type;

        public TypeOfExpression(CsType type)
        {
            this.type = type;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, type);
        }
    }
}
