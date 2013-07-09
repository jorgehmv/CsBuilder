using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Statements;
using CsBuilder.Expressions;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class FieldStatementExtensions
    {
        public static FieldStatement Init(this FieldStatement fieldStatement, Expression expression)
        {
            fieldStatement.InitValue = expression;
            return fieldStatement;
        }

        public static FieldStatement Static(this FieldStatement fieldStatement)
        {
            fieldStatement.Static = true;
            return fieldStatement;
        }

        public static FieldStatement ReadOnly(this FieldStatement fieldStatement)
        {
            fieldStatement.ReadOnly = true;
            return fieldStatement;
        }

        public static FieldStatement OfType(this FieldStatement fieldStatement, CsType type)
        {
            fieldStatement.FieldType = type;
            return fieldStatement;
        }

        public static FieldStatement OfType(this FieldStatement fieldStatement, string typeName)
        {
            fieldStatement.FieldType = typeName.AsType();
            return fieldStatement;
        }
    }
}
