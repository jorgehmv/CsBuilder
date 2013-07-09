using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Elements;
using CsBuilder.Expressions;

namespace CsBuilder.Statements
{
    public class ForeachStatement : Statement
    {
        private const string snippet = "foreach(var {0} in {1}){2}";
        private readonly BlockStatement body;
        private readonly NameElement itemName;
        private readonly Expression collection;

        public ForeachStatement(NameElement itemName, Expression collection, BlockStatement body)
        {
            this.itemName = itemName;
            this.collection=collection;
            this.body = body;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, itemName, collection, body);
        }
    }
}
