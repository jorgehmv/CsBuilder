using System.Collections.Generic;
using System.Linq;
using CsBuilder.Formatters;
using CsBuilder.Types;
using CsBuilder.Utils;

namespace CsBuilder.Expressions
{
    public class NewExpression : Expression
    {
        private readonly CollectionInitializerExpression initializer;
        private readonly IList<Expression> parameters;
        private readonly CsType type;

        public NewExpression(CsType type)
        {
            this.type = type;
            parameters = new List<Expression>();
            initializer = new CollectionInitializerExpression();
        }

        public void AddParam(Expression param)
        {
            parameters.Add(param);
        }

        public void AddMemberInitializer(CollectionMemberInitializerExpression memberInitializer)
        {
            initializer.AddExpression(memberInitializer);
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write("new {0}", type);
            renderer.Write(string.Format("({0})", CodeUtils.Placeholders(parameters.Count)), parameters.ToArray());
            if (initializer.HasInitiCode())
            {
                renderer.Write("{0}", initializer); 
            }
        }
    }
}