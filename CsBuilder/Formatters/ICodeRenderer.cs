#region [ using ]

using System;

#endregion

namespace CsBuilder.Formatters
{
    public interface ICodeWriter : IDisposable
    {
        void PushIndent();

        void PopIndent();

        void ClearIndent();

        void Write(string codeString, params ICode[] codes);

        void WriteLine(string codeString, params ICode[] codes);
    }
}