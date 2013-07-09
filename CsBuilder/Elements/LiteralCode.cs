#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Elements
{
    public class LiteralCode : ICode
    {
        private readonly string code;

        public LiteralCode(string code)
        {
            this.code = code;
        }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            renderer.Write(code);
        }

        #endregion
    }
}