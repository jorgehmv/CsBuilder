using CsBuilder.Statements;
using CsBuilder.Types;

namespace CsBuilder.DSL
{
    public static class DeclarationStatementExtensions
    {

        public static DeclarationStatement OfType(this DeclarationStatement declarationStatement, CsType type)
        {
            declarationStatement.Type = type;
            return declarationStatement;
        }

        public static DeclarationStatement OfType(this DeclarationStatement declarationStatement, string typeName)
        {
            return OfType(declarationStatement, typeName.AsType());
        }
    }
}