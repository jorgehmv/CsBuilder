#region [ using ]

using CsBuilder.Expressions;
using CsBuilder.Formatters;
using CsBuilder.Types;

#endregion

namespace CsBuilder.Statements
{
    public class DeclarationStatement : Statement
    {
        private const string snippet = "{0} {1}";
        private readonly ReferenceExpression declaredVar;

        public DeclarationStatement(ReferenceExpression name)
            : this(name, CsType.String)
        {
        }

        public DeclarationStatement(ReferenceExpression name, CsType type)
        {
            declaredVar = name;
            Type = type;
        }

        public CsType Type { get; set; }

        public ReferenceExpression DeclaredVar()
        {
            return declaredVar;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, Type, declaredVar);
        }
    }
}