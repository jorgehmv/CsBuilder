using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CsBuilder.Formatters;
using CsBuilder.Elements;
using CsBuilder.Types;
using CsBuilder.Expressions;
using CsBuilder.Utils;

namespace CsBuilder.Statements
{
    public class ConstructorStatement : Statement, IAccessModifiable
    {
        private const string snippet = "{0} {1}({2}){3}{4}";
        private readonly CsType type;
        private readonly BlockStatement body;
        private readonly ParameterListStatement parameterList;
        private readonly IList<Expression> baseParameters;

        public bool CallBaseCtor { get; set; }

        public ConstructorStatement(CsType type, BlockStatement block)
        {
            AccessModifier = AccessModifier.Public;

            this.type = type;
            body = block;
            parameterList = new ParameterListStatement();
            baseParameters = new List<Expression>();
        }

        public void AddParam(ParameterStatement parameter)
        {
            parameterList.AddParam(parameter);
        }

        public void AddBaseParam(Expression expression)
        {
            baseParameters.Add(expression);
        }
        
        public override void Render(ICodeWriter renderer)
        {
            renderer.Write("{0} {1}({2})", AccessModifier, type.GetName(), parameterList);
            if (CallBaseCtor)
            {
                renderer.Write(string.Format(" : base({0})", CodeUtils.Placeholders(baseParameters.Count)), baseParameters.ToArray());
            }
            renderer.Write("{0}", body);
        }
        
        #region IAccessModifiable Members

        public AccessModifier AccessModifier { get; set; }

        #endregion
    }
}
