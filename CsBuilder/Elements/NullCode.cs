#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Elements
{
    public class NullCode : ICode
    {
        public static readonly ICode Instance = new NullCode();

        private NullCode()
        {
        }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            renderer.Write(string.Empty);
        }

        #endregion
    }
}