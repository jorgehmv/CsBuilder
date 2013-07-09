using CsBuilder.Statements;
using CsBuilder.Types;
using CsBuilder.Comments;

namespace CsBuilder.DSL
{
    public static class MethodStatementExtensions
    {
        public static MethodStatement Param(this MethodStatement methodStatement, string name, CsType type)
        {
            methodStatement.AddParam(new ParameterStatement(name, type));
            return methodStatement;
        }

        public static MethodStatement Param(this MethodStatement methodStatement, string name, string typeName)
        {
            return Param(methodStatement, name, typeName.AsType());
        }

        public static MethodStatement OfType(this MethodStatement methodStatement, CsType type)
        {
            methodStatement.ReturnType = type;
            return methodStatement;
        }

        public static MethodStatement OfType(this MethodStatement methodStatement, string typeName)
        {
            return OfType(methodStatement, typeName.AsType());
        }

    }
}