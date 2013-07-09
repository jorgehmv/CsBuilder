#region [ using ]

using CsBuilder.Formatters;

#endregion

namespace CsBuilder
{
    public interface ICode
    {
        void Render(ICodeWriter renderer);
    }
}