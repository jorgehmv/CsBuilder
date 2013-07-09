#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public abstract class Statement : ICode
    {
        #region ICode Members

        public abstract void Render(ICodeWriter renderer);

        #endregion

        public Statement Semicolon()
        {
            return new SemicolonStatement(this);
        }
    }
}