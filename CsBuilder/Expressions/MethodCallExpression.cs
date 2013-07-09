#region [ using ]

using System.Collections.Generic;
using System.Linq;
using CsBuilder.Formatters;
using CsBuilder.Utils;
using CsBuilder.Types;

#endregion

namespace CsBuilder.Expressions
{
    public class MethodCallExpression : Expression
    {
        private readonly ICode caller;
        private readonly string name;
        private readonly IList<Expression> parameters;
        private readonly IList<CsType> genericArgumentTypes;

        public MethodCallExpression(string name, Expression expression)
        {
            this.name = name;
            this.caller = expression;
            parameters = new List<Expression>();
            genericArgumentTypes = new List<CsType>();
        }

        public MethodCallExpression(string name, CsType csType)
        {
            this.name = name;
            this.caller = csType;
            IsStaticMethodCall = true;
            parameters = new List<Expression>();
            genericArgumentTypes = new List<CsType>();
        }

        public void AddParam(Expression param)
        {
            parameters.Add(param);
        }

        public void AddGenericArgument(CsType argument)
        {
            genericArgumentTypes.Add(argument);
        }

        public bool IsStaticMethodCall { get; protected set; }

        public override void Render(ICodeWriter renderer)
        {
            if (caller != null)
            {
                renderer.Write("{0}.", caller); 
            }
            renderer.Write(name);
            if (genericArgumentTypes.Count > 0)
            {
                string placeholders = CodeUtils.Placeholders(genericArgumentTypes.Count);
                renderer.Write(string.Format("<{0}>", placeholders), genericArgumentTypes.ToArray());
            }

            renderer.Write(string.Format("({0})", CodeUtils.Placeholders(parameters.Count)), parameters.ToArray());
        }
    }
}
