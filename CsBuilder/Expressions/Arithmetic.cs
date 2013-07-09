using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Operators;

namespace CsBuilder.Expressions
{
    public class MultiplyOperation : Expression
    {
        private const string snippet = "{0} {1} {2}";
        private readonly Expression left;
        private readonly Expression right;

        public MultiplyOperation(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, left, ArithmeticOperator.Multiply, right);
        }
    }

    public class DivideOperation : Expression
    {
        private const string snippet = "{0} {1} {2}";
        private readonly Expression left;
        private readonly Expression right;

        public DivideOperation(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, left, ArithmeticOperator.Divide, right);
        }
    }

    public class PlusOperation : Expression
    {
        private const string snippet = "{0} {1} {2}";
        private readonly Expression left;
        private readonly Expression right;

        public PlusOperation(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, left, ArithmeticOperator.Plus, right);
        }
    }

    public class MinusOperation : Expression
    {
        private const string snippet = "{0} {1} {2}";
        private readonly Expression left;
        private readonly Expression right;

        public MinusOperation(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, left, ArithmeticOperator.Minus, right);
        }
    }

    public class PlusPlusOperation : Expression
    {
        private const string snippet = "{0}{1}";
        private readonly Expression expression;

        public PlusPlusOperation(Expression expression)
        {
            this.expression = expression;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, expression, ArithmeticOperator.PlusPlus);
        }
    }
}
