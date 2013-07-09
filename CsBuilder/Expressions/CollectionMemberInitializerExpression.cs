using System.Collections.Generic;
using System.Linq;
using CsBuilder.Formatters;
using CsBuilder.Utils;

namespace CsBuilder.Expressions
{
    public class CollectionMemberInitializerExpression : Expression
    {
        private readonly IList<Expression> values;

        public CollectionMemberInitializerExpression()
        {
            values = new List<Expression>();
        }

        public void AddValue(Expression expression)
        {
            values.Add(expression);
        }

        public override void Render(ICodeWriter renderer)
        {
            if (values.Count > 1)
            {
                string placeholders = CodeUtils.Placeholders(values.Count);
                renderer.Write(string.Format("{{ {0} }},", placeholders), values.ToArray());
            }
            else if (values.Count > 0)
            {
                renderer.Write("{0},", values.ToArray());
            }
        }
    }
}