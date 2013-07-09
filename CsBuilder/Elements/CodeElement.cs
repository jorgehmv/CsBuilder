#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Elements
{
    public abstract class CodeElement : ICode
    {
        protected readonly string name;

        protected CodeElement(string name)
        {
            this.name = name;
        }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            renderer.Write(name);
        }

        #endregion
    }
}