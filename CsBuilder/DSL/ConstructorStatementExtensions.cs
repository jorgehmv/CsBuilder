using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Statements;
using CsBuilder.Expressions;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class ConstructorStatementExtensions
    {
     
        public static ConstructorStatement Param(this ConstructorStatement constructorStatement, string name, CsType type)
        {
            constructorStatement.AddParam(new ParameterStatement(name, type));
            return constructorStatement;
        }

        public static ConstructorStatement Param(this ConstructorStatement constructorStatement, string name, string typeName)
        {
            return Param(constructorStatement, name, typeName.AsType());
        }

        public static ConstructorStatement BaseParams(this ConstructorStatement constructorStatement,
                                                  params Expression[] parameters)
        {
            constructorStatement.CallBaseCtor = true;
            foreach (Expression parameter in parameters)
            {
                constructorStatement.AddBaseParam(parameter);
            }

            return constructorStatement;
        }
    }
}
