using System;
using CsBuilder.Elements;
using CsBuilder.Expressions;
using CsBuilder.Statements;
using CsBuilder.Comments;

namespace CsBuilder.DSL
{
    public static class BlockStatementExtensions
    {
        public static DeclarationStatement Declare(this BlockStatement blockStatement, ReferenceExpression refExpression)
        {
            var declarationStatement = new DeclarationStatement(refExpression);
            blockStatement.AddStatement(declarationStatement.Semicolon());
            return declarationStatement;
        }

        public static AssignmentExpression Assign(this BlockStatement blockStatement, Expression expression)
        {
            var assignmentExpression = new AssignmentExpression {RightSide = expression};
            blockStatement.AddStatement(assignmentExpression.AsStatement());
            return assignmentExpression;
        }

        public static Statement Statement(this BlockStatement blockStatement, Expression expression)
        {
            var statement = expression.AsStatement();
            blockStatement.AddStatement(statement);
            return statement;
        }

        public static Statement Statement(this BlockStatement blockStatement, Statement statement)
        {
            blockStatement.AddStatement(statement);
            return statement;
        }

        public static WhileStatement While(this BlockStatement blockStatement, Expression expression,
                                           Action<BlockStatement> block)
        {
            var nestedBlockStatement = new BlockStatement();
            block(nestedBlockStatement);

            var whileStatement = new WhileStatement(expression, nestedBlockStatement);
            blockStatement.AddStatement(whileStatement);
            return whileStatement;
        }

        public static ForeachStatement Foreach(this BlockStatement blockStatement, string itemName, Expression expression,
                                           Action<BlockStatement> block)
        {
            var nestedBlockStatement = new BlockStatement();
            block(nestedBlockStatement);

            var foreachStatement = new ForeachStatement(new NameElement(itemName), expression, nestedBlockStatement);
            blockStatement.AddStatement(foreachStatement);
            return foreachStatement;
        }

        public static IfStatement If(this BlockStatement blockStatement, Expression expression,
                                     Action<BlockStatement> block)
        {
            var nestedBlockStatement = new BlockStatement();
            block(nestedBlockStatement);

            var ifStatement = new IfStatement(expression, nestedBlockStatement);
            blockStatement.AddStatement(ifStatement);
            return ifStatement;
        }

        public static ReturnStatement Return(this BlockStatement blockStatement, Expression expression)
        {
            var returnStatement = new ReturnStatement(expression);
            blockStatement.AddStatement(returnStatement);
            return returnStatement;
        }

        public static YieldReturnStatement YieldReturn(this BlockStatement blockStatement, Expression expression)
        {
            var yieldReturnStatement = new YieldReturnStatement(expression);
            blockStatement.AddStatement(yieldReturnStatement);
            return yieldReturnStatement;
        }

        public static SingleComment Comment(this BlockStatement blockStatement, string comment)
        {
            var singleComment = new SingleComment(comment);
            blockStatement.AddStatement(singleComment);
            return singleComment;
        }

        public static ForStatement For(this BlockStatement blockStatement, int init)
        {
            var forStatement = new ForStatement { InitValue = init };
            blockStatement.AddStatement(forStatement);
            return forStatement;
        }

        public static ForStatement To(this ForStatement forStatement, Expression toValue)
        {
            forStatement.Condition = forStatement.Variable <= toValue;
            return forStatement;
        }

        public static ForStatement Do(this ForStatement forStatement, Action<BlockStatement> block)
        {
            var nestedBlockStatement = new BlockStatement();
            block(nestedBlockStatement);

            forStatement.Body = nestedBlockStatement;
            return forStatement;
        }

    }
}