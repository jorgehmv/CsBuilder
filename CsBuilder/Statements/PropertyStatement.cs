#region [ using ]

using System.Linq;
using System.Collections.Generic;
using CsBuilder.Elements;
using CsBuilder.Formatters;
using CsBuilder.Types;

#endregion

namespace CsBuilder.Statements
{
    public class PropertyStatement : Statement, IAccessModifiable, IModifiable, IAttributable
    {
        private const string snippet = "{0} {1} {2} {3} {4}";
        private readonly IList<AttributeStatement> attributes;
        private readonly BlockStatement blockStatement;
        private readonly NameElement name;
        private GetAccesor getAccesor;
        private SetAccesor setAccesor;

        public PropertyStatement(string name)
        {
            AccessModifier = AccessModifier.Public;
            getAccesor = GetAccesor.Empty;
            Modifier = Modifier.Virtual;
            ReturnType = CsType.String;
            setAccesor = SetAccesor.Empty;

            this.name = new NameElement(name);
            attributes = new List<AttributeStatement>();
            blockStatement = new BlockStatement {SingleLine = true};
        }

        public CsType ReturnType { get; set; }

        public GetAccesor GetAccesor
        {
            get { return getAccesor; }
            set
            {
                getAccesor = value;
                if (getAccesor != null)
                {
                    blockStatement.SingleLine = false;
                }
            }
        }

        public SetAccesor SetAccesor
        {
            get { return setAccesor; }
            set
            {
                setAccesor = value;
                if (setAccesor != null)
                {
                    blockStatement.SingleLine = false;
                }
            }
        }

        #region IAccessModifiable Members

        public AccessModifier AccessModifier { get; set; }

        #endregion

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

        #region IModifiable Members

        public Modifier Modifier { get; set; }

        #endregion

        public override void Render(ICodeWriter renderer)
        {
            blockStatement.AddStatement(GetAccesor);
            blockStatement.AddStatement(SetAccesor);

            if (attributes.Count > 0)
            {
                renderer.Write("{0} ", attributes.First());
                renderer.WriteLine("");
                foreach (AttributeStatement attribute in attributes.Skip(1))
                {
                    renderer.WriteLine("{0} ", attribute);
                }

                renderer.WriteLine(snippet, AccessModifier, Modifier, ReturnType, name, blockStatement);
            }
            else
            {
                renderer.Write(snippet, AccessModifier, Modifier, ReturnType, name, blockStatement);
            }
        }
    }
}