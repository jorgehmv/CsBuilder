using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;

namespace CsBuilder.Operators
{
    public class ArithmeticOperator : ICode
    {
        public static readonly ArithmeticOperator Multiply = new ArithmeticOperator("*");
        public static readonly ArithmeticOperator Divide = new ArithmeticOperator("/");
        public static readonly ArithmeticOperator Plus = new ArithmeticOperator("+");
        public static readonly ArithmeticOperator Minus = new ArithmeticOperator("-");
        public static readonly ArithmeticOperator PlusPlus = new ArithmeticOperator("++");

        private readonly string operatorString;

        private ArithmeticOperator(string operatorString)
        {
            this.operatorString = operatorString;
        }

        public void Render(ICodeWriter renderer)
        {
            renderer.Write(operatorString);
        }
    }
}
