using System;
using CsBuilder.Statements;
using CsBuilder.Types;
using CsBuilder.Comments;

namespace CsBuilder.DSL
{
    public static class ClassStatementExtensions
    {
        public static PropertyStatement Property(this ClassStatement classStatement, string name)
        {
            var propertyStatement = new PropertyStatement(name);
            classStatement.AddProperty(propertyStatement);
            return propertyStatement;
        }

        public static FieldStatement Field(this ClassStatement classStatement, string name)
        {
            var fieldStatement = new FieldStatement(name);
            classStatement.AddField(fieldStatement);
            return fieldStatement;
        }

        public static MethodStatement Method(this ClassStatement classStatement, string name,
                                             Action<BlockStatement> block)
        {
            var blockStatement = new BlockStatement();
            block(blockStatement);

            var methodStatement = new MethodStatement(name, blockStatement);
            classStatement.AddMethod(methodStatement);
            return methodStatement;
        }

        public static ConstructorStatement Ctor(this ClassStatement classStatement, Action<BlockStatement> block)
        {
            var blockStatement = new BlockStatement();
            block(blockStatement);
            
            var ctorStatement = new ConstructorStatement(classStatement.CsType, blockStatement);
            classStatement.AddConstructor(ctorStatement);
            return ctorStatement;
        }

        public static ClassStatement NestedClass(this ClassStatement classStatement, string name, Action<ClassStatement> @class)
        {
            var nestedClassStatement = new ClassStatement(name);
            @class(nestedClassStatement);
            classStatement.AddNestedClass(nestedClassStatement);
            return nestedClassStatement;
        }

        public static ClassStatement Inherits(this ClassStatement classStatement, CsType baseType)
        {
            classStatement.Base = baseType;
            return classStatement;
        }

        public static ClassStatement Inherits(this ClassStatement classStatement, string baseTypeName)
        {
            return Inherits(classStatement, baseTypeName.AsType());
        }

        public static ClassStatement Implements(this ClassStatement classStatement, CsType interfaceType)
        {
            classStatement.AddInterface(interfaceType);
            return classStatement;
        }

        public static ClassStatement Implements(this ClassStatement classStatement, string interfaceTypeTypeName)
        {
            return Implements(classStatement, interfaceTypeTypeName.AsType());
        }
    }
}