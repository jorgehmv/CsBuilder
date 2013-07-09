#region [ using ]

using System;
using CsBuilder.Expressions;
using CsBuilder.Statements;
using CsBuilder.Types;
using CsBuilder.Elements;

#endregion

namespace CsBuilder.DSL
{
    public static class Cs
    {
        public static ClassStatement Class(string name, Action<ClassStatement> @class)
        {
            var classStatement = new ClassStatement(name);
            @class(classStatement);
            return classStatement;
        }

        public static ReferenceExpression Var(string name)
        {
            return new ReferenceExpression(name);
        }

        public static LambdaExpression Lambda(Expression expression)
        {
            return new LambdaExpression(expression);
        }

        public static ReferenceExpression LambdaParam()
        {
            return Var(LambdaExpression.DefaultParamName);
        }

        public static ParameterStatement Param(string name, CsType type)
        {
            return new ParameterStatement(name, type);
        }

        public static MethodCallExpression Call(string name)
        {
            return new MethodCallExpression(name, (Expression)null);
        }

        public static Expression Base()
        {
            return Expression.Base;
        }

        public static Expression This()
        {
            return Expression.This;
        }

        public static DefaultExpression Default(CsType type)
        {
            return new DefaultExpression(type);
        }

        public static AssignmentExpression Assign(string leftSide, Expression rightSide)
        {
            return Assign(Cs.Var(leftSide), rightSide);
        }

        public static AssignmentExpression Assign(ReferenceExpression leftSide, Expression rightSide)
        {
            return new AssignmentExpression(leftSide, rightSide);
        }

        public static TypeOfExpression TypeOf(string typeName)
        {
            return TypeOf(typeName.AsType());
        }

        public static TypeOfExpression TypeOf(CsType type)
        {
            return new TypeOfExpression(type);
        }

        public static ICode Empty()
        {
            return NullCode.Instance;
        }

        public static ReferenceExpression Value
        {
            get
            {
                return Cs.Var("value");
            }
        }

        #region [ Types ]
        public static GenericType IEnumerableOf(CsType argumentType)
        {
            return new IEnumerableType(argumentType);
        }

        public static GenericType IEnumerableOf(string argumentTypeName)
        {
            return IEnumerableOf(argumentTypeName.AsType());
        }

        public static CsType Enumerable()
        {
            return new CustomType("Enumerable");
        }

        public static CsType Dictionary(CsType keyType, CsType valueType)
        {
            return new DictionaryType(keyType, valueType);
        }

        public static CsType List(CsType type)
        {
            return new ListType(type);
        }
        #endregion
    }
}