#region [ using ]

using System.Collections.Generic;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class BlockStatement : Statement
    {
        private readonly IList<Statement> statements;

        public BlockStatement()
        {
            statements = new List<Statement>();
        }

        public bool SingleLine { get; set; }

        public void AddStatement(Statement statement)
        {
            if (statement != null)
            {
                statements.Add(statement);
            }
        }

        public override void Render(ICodeWriter renderer)
        {
            var bracedCode = new BracedCode(statements)
                                 {
                                     SingleLine = SingleLine
                                 };

            bracedCode.Render(renderer);
        }
    }
}