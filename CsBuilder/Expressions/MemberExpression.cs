#region [ using ]

using CsBuilder.Elements;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Expressions
{
    public class ReferenceExpression : Expression
    {
        private readonly NameElement name;
        private readonly Expression owner;
        private readonly ReferenceExpression reference;

        public ReferenceExpression(string name)
        {
            this.name = new NameElement(name);
        }

        public ReferenceExpression(Expression owner, string name)
        {
            this.owner = owner;
            this.name = new NameElement(name);
        }

        public ReferenceExpression(Expression owner, ReferenceExpression reference)
        {
            this.owner = owner;
            this.reference = reference;
        }

        public Expression GetSelfWithNullCheck()
        {
            if (!ReferenceEquals(owner, null) && owner is ReferenceExpression)
            {
                return new TernaryOperatorExpression(GetNullChecks(), this, Null);
            }

            return this;
        }

        private Expression GetNullChecks()
        {
            var ownerRef = owner as ReferenceExpression;
            if (!ReferenceEquals(ownerRef, null))
            {
                return ownerRef.GetNullChecks() & owner != null;
            }

            return True;
        }

        public override void Render(ICodeWriter renderer)
        {
            if (!ReferenceEquals(reference, null))
            {
                renderer.Write("{0}.{1}", owner, reference);
            }
            else if (ReferenceEquals(owner, null))
            {
                renderer.Write("{0}", name);
            }
            else
            {
                renderer.Write("{0}.{1}", owner, name);
            }
        }
    }
}