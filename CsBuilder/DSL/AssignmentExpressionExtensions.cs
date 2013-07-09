using CsBuilder.Expressions;

namespace CsBuilder.DSL
{
    public static class AssignmentExpressionExtensions
    {
        public static AssignmentExpression To(this AssignmentExpression assignmentExpression,
                                              ReferenceExpression reference)
        {
            assignmentExpression.LeftSide = reference;
            return assignmentExpression;
        }
    }
}