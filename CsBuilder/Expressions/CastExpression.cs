#region [ using ]

using CsBuilder.Formatters;
using CsBuilder.Types;

#endregion

namespace CsBuilder.Expressions
{
    public class CastExpression : Expression
    {
        private const string snippet = "(({0}){1})";
        private readonly Expression castedExpression;
        private readonly CsType type = CsType.Int;

        public CastExpression(Expression castedExpression, CsType type)
        {
            this.castedExpression = castedExpression;
            this.type = type;
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, type, castedExpression);
        }
    }
}