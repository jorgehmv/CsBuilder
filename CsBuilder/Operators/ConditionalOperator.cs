#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Operators
{
    public class ConditionalOperator : ICode
    {
        public static readonly ConditionalOperator And = new ConditionalOperator("&&");
        public static readonly ConditionalOperator Or = new ConditionalOperator("||");
        public static readonly ConditionalOperator Not = new ConditionalOperator("!");

        private readonly string operatorString;

        private ConditionalOperator(string operatorString)
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