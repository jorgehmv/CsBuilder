#region [ using ]

using CsBuilder.Elements;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public class UsingStatement : Statement
    {
        private const string snippet = "using {0}{1};";
        private readonly ICode code;
        private readonly NameElement @namespace;

        public UsingStatement(string @namespace, ICode code)
        {
            this.@namespace = new NameElement(@namespace);
            this.code = code;
        }

        public string Alias { get; set; }

        public override void Render(ICodeWriter renderer)
        {
            renderer.WriteLine(snippet, !string.IsNullOrEmpty(Alias) ? new NameElement("Alias") : NullCode.Instance, @namespace);
            renderer.Write("{0}", code);
        }
    }
}