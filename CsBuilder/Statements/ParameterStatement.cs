#region [ using ]

using System.Collections.Generic;
using CsBuilder.Expressions;
using CsBuilder.Formatters;
using CsBuilder.Types;

#endregion

namespace CsBuilder.Statements
{
    public class ParameterStatement : DeclarationStatement, IAttributable
    {
        private readonly IList<AttributeStatement> attributes;

        public ParameterStatement(string name, CsType type)
            : base(new ReferenceExpression(name), type)
        {
            attributes = new List<AttributeStatement>();
        }

        #region IAttributable Members

        public void AddAttribute(AttributeStatement attributeStatement)
        {
            attributes.Add(attributeStatement);
        }

        public IEnumerable<AttributeStatement> Attributes
        {
            get { return attributes; }
        }

        #endregion

        public override void Render(ICodeWriter renderer)
        {
            foreach (AttributeStatement attribute in attributes)
            {
                renderer.Write("{0}", attribute);
            }
            base.Render(renderer);
        }
    }
}