using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Elements;
using CsBuilder.Types;
using CsBuilder.Expressions;

namespace CsBuilder.Statements
{
    public class FieldStatement : Statement, IAccessModifiable, IModifiable, IAttributable
    {
        private readonly IList<AttributeStatement> attributes;
        private readonly BlockStatement blockStatement;
        private readonly NameElement name;

        public FieldStatement(string name)
        {
            AccessModifier = AccessModifier.Public;
            Modifier = Modifier.Virtual;
            FieldType = CsType.String;

            this.name = new NameElement(name);
            attributes = new List<AttributeStatement>();
            blockStatement = new BlockStatement {SingleLine = true};
        }

        public CsType FieldType { get; set; }

        public IEnumerable<AttributeStatement> Attributes
        {
            get { throw new NotImplementedException(); }
        }

        public void AddAttribute(AttributeStatement attributeStatement)
        {
            throw new NotImplementedException();
        }

        public bool Static { get; set; }

        public bool ReadOnly { get; set; }

        public Modifier Modifier { get; set; }

        public AccessModifier AccessModifier { get; set; }

        public Expression InitValue { get; set; }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write("{0}", AccessModifier);
            if (Static)
            {
                renderer.Write(" {0}", Modifier.Static); 
            }
            if (ReadOnly)
            {
                renderer.Write(" {0}", Modifier.ReadOnly); 
            }
            renderer.Write(" {0}", FieldType);
            renderer.Write(" {0}", name);
            if (!object.ReferenceEquals(InitValue, null))
            {
                renderer.Write(" = {0}", InitValue);
            }
            renderer.Write(";");
        }

    }
}
