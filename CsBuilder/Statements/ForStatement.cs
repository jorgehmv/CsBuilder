using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Expressions;

namespace CsBuilder.Statements
{
    public class ForStatement : Statement 
    {
        private const string snippet = "for(int {0} = {1}; {2}; {3}){4}";
        public readonly static ReferenceExpression ForVar = new ReferenceExpression("i");

        public Expression Variable { get; set; }
        public Expression InitValue { get; set; }
        public Expression Condition { get; set; }
        public Expression Increment { get; set; }
        public BlockStatement Body { get; set; }

        public ForStatement()
        {
            Variable = ForVar;
            InitValue = 0;
            Condition = Variable < 0;
            Increment = Variable.PlusPlus();
            Body = new BlockStatement();
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, Variable, InitValue, Condition, Increment, Body);
        }
    }
}
