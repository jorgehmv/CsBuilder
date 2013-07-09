using CsBuilder.Formatters;

namespace CsBuilder.Expressions
{
    public class LambdaExpression : Expression
    {
        private const string snippet = "{0} => {1}";
        // we just support single line lambdas for now
        private readonly Expression expression;
        private ReferenceExpression param;
        private string paramName;

        public const string DefaultParamName = "p";

        public LambdaExpression(Expression expression)
        {
            ParamName = DefaultParamName;
            this.expression = expression;
        }

        public string ParamName
        {
            get { return paramName; }
            set
            {
                paramName = value;
                param = new ReferenceExpression(value);
            }
        }

        public ReferenceExpression Param
        {
            get { return param; }
        }

        public override void Render(ICodeWriter renderer)
        {
            renderer.Write(snippet, Param, expression);
        }
    }
}