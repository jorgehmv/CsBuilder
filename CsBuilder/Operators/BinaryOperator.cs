using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;

namespace CsBuilder.Operators
{
    public class BinaryOperator : ICode
    {
        public static readonly BinaryOperator And = new BinaryOperator("&");
        public static readonly BinaryOperator Or = new BinaryOperator("|");
        public static readonly BinaryOperator Not = new BinaryOperator("!");

        private readonly string operatorString;

        private BinaryOperator(string operatorString)
        {
            this.operatorString = operatorString;
        }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            renderer.Write(operatorString);
        }

        #endregion
    }
}
