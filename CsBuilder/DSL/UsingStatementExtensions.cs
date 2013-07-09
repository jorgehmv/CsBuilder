using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Statements;

namespace CsBuilder.DSL
{
    public static class UsingStatementExtensions
    {
        public static UsingStatement WithAlias(this UsingStatement usingStatement, string alias)
        {
            usingStatement.Alias = alias;
            return usingStatement;
        }
    }
}
