#region [ using ]

using System.Collections.Generic;
using CsBuilder.Elements;
using CsBuilder.Formatters;
using CsBuilder.Types;
using CsBuilder.Comments;

#endregion

namespace CsBuilder.Statements
{
    public class MethodStatement : BlockStatement, IAccessModifiable, IModifiable, IAttributable
    {
        private const string snippet = "{0} {1} {2} {3}({4}){5}";
        private readonly IList<AttributeStatement> attributes;
        private readonly BlockStatement body;
        private readonly NameElement name;
        private readonly ParameterListStatement parameterList;

        public MethodStatement(string name, BlockStatement block)
        {
            AccessModifier = AccessModifier.Public;
            Modifier = Modifier.Virtual;
            ReturnType = CsType.Void;

            this.name = new NameElement(name);
            body = block;
            parameterList = new ParameterListStatement();
            attributes = new List<AttributeStatement>();
        }

        public CsType ReturnType { get; set; }

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

        public void AddParam(ParameterStatement parameter)
        {
            parameterList.AddParam(parameter);
        }

        public override void Render(ICodeWriter renderer)
        {
            foreach (AttributeStatement attribute in attributes)
            {
                renderer.Write("{0} ", attribute);
            }
            renderer.Write(snippet, AccessModifier, Modifier, ReturnType, name, parameterList, body);
        }
    }
}