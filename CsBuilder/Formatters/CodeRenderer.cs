#region [ using ]

using System;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace CsBuilder.Formatters
{
    public class CodeWriter : ICodeWriter
    {
        private readonly string indent;
        private readonly TextWriter textWriter;
        private int indentLevel;

        public CodeWriter(TextWriter textWiter)
            : this(textWiter, "\t")
        {
        }

        public CodeWriter(TextWriter textWriter, string indent)
        {
            this.textWriter = textWriter;
            this.indent = indent;
        }

        #region ICodeWriter Members

        public void PushIndent()
        {
            indentLevel++;
        }

        public void PopIndent()
        {
            if (indentLevel == 0)
                throw new InvalidOperationException("Cannot pop indent when indent level is zero.");
            indentLevel--;
        }

        public void ClearIndent()
        {
            indentLevel = 0;
        }

        public void Write(string codeString, params ICode[] codes)
        {
            if (codes == null || codes.Length == 0)
            {
                textWriter.Write(codeString);
                return;
            }

            var regex = new Regex(@"\{\d+\}");
            int index = 0;
            foreach (Match match in regex.Matches(codeString))
            {
                textWriter.Write(codeString.Substring(index, match.Index - index));
                var nextCode = codes[int.Parse(match.Value.Substring(1, match.Value.Length - 2))];
                if (nextCode != null)
                {
                    nextCode.Render(this);
                }
                index = match.Index + match.Length;
            }

            textWriter.Write(codeString.Substring(index, codeString.Length - index));
        }

        public void WriteLine(string codeString, params ICode[] codes)
        {
            Write(GetIndentation() + codeString + Environment.NewLine, codes);
        }

        void IDisposable.Dispose()
        {
            textWriter.Dispose();
        }

        #endregion

        private string GetIndentation()
        {
            string indents = string.Empty;
            for (int level = 0; level < indentLevel; level++)
            {
                indents += indent;
            }

            return indents;
        }
    }
}