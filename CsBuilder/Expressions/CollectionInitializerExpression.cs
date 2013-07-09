using CsBuilder.Formatters;
using CsBuilder.Statements;

namespace CsBuilder.Expressions
{
    public class CollectionInitializerExpression : Expression
    {
        private readonly BracedCode bracedCode;

        public CollectionInitializerExpression()
        {
            bracedCode = new BracedCode();
        }

        public void AddExpression(CollectionMemberInitializerExpression initializer)
        {
            bracedCode.AddCode(initializer);
        }

        public bool HasInitiCode()
        {
            return bracedCode.HasCode();
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write("{0}", bracedCode);
        }
    }
}