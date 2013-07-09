#region [ using ]

using CsBuilder.DSL;
using CsBuilder.Formatters;
using CsBuilder.Statements;

#endregion

namespace CsBuilder.Expressions
{
    public abstract class Expression : ICode
    {
        public static readonly Expression True = new ConstantExpression("true");
        public static readonly Expression False = new ConstantExpression("false");
        public static readonly Expression Null = new ConstantExpression("null");
        public static readonly Expression Base = new ConstantExpression("base");
        public static readonly Expression This = new ConstantExpression("this");

        #region ICode Members

        public abstract void Render(ICodeWriter renderer);

        #endregion

        public Statement AsStatement()
        {
            return new SemicolonStatement(this);
        }

        public bool IsBool { get; set; }

        public static Expression operator ==(Expression left, Expression right)
        {
            return new EqualityComparison(left, right);
        }

        public static Expression operator !=(Expression left, Expression right)
        {
            return new InequalityComparison(left, right);
        }

        public static Expression operator <=(Expression left, Expression right)
        {
            return new LessThanOrEqualsToComparison(left, right);
        }

        public static Expression operator >=(Expression left, Expression right)
        {
            return new GreaterThanOrEqualsToComparison(left, right);
        }

        public static Expression operator <(Expression left, Expression right)
        {
            return new LessThanComparison(left, right);
        }

        public static Expression operator >(Expression left, Expression right)
        {
            return new GreaterThanComparison(left, right);
        }

        public static Expression operator &(Expression left, Expression right)
        {
            return new AndCondition(left, right);
        }

        public static Expression operator |(Expression left, Expression right)
        {
            return new OrCondition(left, right);
        }

        public static Expression operator *(Expression left, Expression right)
        {
            return new MultiplyOperation(left, right);
        }

        public static Expression operator /(Expression left, Expression right)
        {
            return new DivideOperation(left, right);
        }

        public static Expression operator +(Expression left, Expression right)
        {
            return new PlusOperation(left, right);
        }

        public static Expression operator -(Expression left, Expression right)
        {
            return new MinusOperation(left, right);
        }

        public Expression PlusPlus()
        {
            return new PlusPlusOperation(this);
        }

        public static Expression operator !(Expression expression)
        {
            return new NotCondition(expression);
        }

        public static implicit operator Expression(int value)
        {
            return value.Value();
        }

        public static implicit operator Expression(string value)
        {
            return value.Value();
        }

        public ReferenceExpression Ref(string refName)
        {
            return new ReferenceExpression(this, refName);
        }

        public ReferenceExpression Ref(ReferenceExpression reference)
        {
            return new ReferenceExpression(this, reference);
        }
    }
}