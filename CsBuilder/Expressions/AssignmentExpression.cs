#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Expressions
{
    public class AssignmentExpression : Expression
    {
        private const string snippet = "{0} = {1}";

        public AssignmentExpression()
            : this(new ConstantExpression("notDefinedVar"), new ConstantExpression("notDefinedValue"))
        {
        }

        public AssignmentExpression(Expression leftSide, Expression rightSide)
        {
            LeftSide = leftSide;
            RightSide = rightSide;
        }

        public Expression LeftSide { get; set; }
        public Expression RightSide { get; set; }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, LeftSide, RightSide);
        }
    }
}