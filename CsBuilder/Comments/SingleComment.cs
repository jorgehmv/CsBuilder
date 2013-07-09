using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Statements;

namespace CsBuilder.Comments
{
    public class SingleComment : Statement
    {
        private const string snippet = "// {0}";
        private readonly string comment;

        public SingleComment(string comment)
        {
            this.comment = comment;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(string.Format(snippet, comment));
        }
    }
}
