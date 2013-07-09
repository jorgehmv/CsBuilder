using System;
using CsBuilder.Statements;
using CsBuilder.Types;
using CsBuilder.Elements;

namespace CsBuilder.DSL
{
    public static class PropertyStatementExtensions
    {
        public static PropertyStatement Get(this PropertyStatement propertyStatement, Action<BlockStatement> block,
                                            bool multiLine = false, AccessModifier accessModifier = null)
        {
            var blockStatement = new BlockStatement {SingleLine = !multiLine};
            block(blockStatement);

            var getAccesor = new GetAccesor(blockStatement);
            propertyStatement.GetAccesor = getAccesor;
            propertyStatement.GetAccesor.AccessModifier = accessModifier;

            return propertyStatement;
        }

        public static PropertyStatement Set(this PropertyStatement propertyStatement, Action<BlockStatement> block,
                                            bool multiLine = false, AccessModifier accessModifier = null)
        {
            var blockStatement = new BlockStatement { SingleLine = !multiLine };
            block(blockStatement);

            var setAccesor = new SetAccesor(blockStatement);
            propertyStatement.SetAccesor = setAccesor;
            propertyStatement.GetAccesor.AccessModifier = accessModifier;

            return propertyStatement;
        }

        public static PropertyStatement GetterOnly(this PropertyStatement propertyStatement)
        {
            propertyStatement.SetAccesor = null;
            return propertyStatement;
        }

        public static PropertyStatement OfType(this PropertyStatement propertyStatement, CsType type)
        {
            propertyStatement.ReturnType = type;
            return propertyStatement;
        }

        public static PropertyStatement OfType(this PropertyStatement propertyStatement, string typeName)
        {
            return OfType(propertyStatement, typeName.AsType());
        }

        
    }
}