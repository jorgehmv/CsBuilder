using System.Collections.Generic;
using System.Linq;
using CsBuilder.Expressions;
using CsBuilder.Formatters;
using CsBuilder.Types;
using CsBuilder.Utils;

namespace CsBuilder.Statements
{
    public class AttributeStatement : ICode
    {
        private readonly IList<Expression> parameters;
        private readonly CsType type;

        public AttributeStatement(CsType type)
        {
            this.type = type;
            parameters = new List<Expression>();
        }

        #region ICode Members

        public void Render(ICodeWriter renderer)
        {
            renderer.Write("[{0}", type);
            if (parameters.Count > 0)
            {
                renderer.Write(string.Format("({0})", CodeUtils.Placeholders(parameters.Count)), parameters.ToArray());
            }
            renderer.Write("]");
        }

        #endregion

        public void AddParam(Expression parameter)
        {
            parameters.Add(parameter);
        }
    }
}