#region [ using ]

using CsBuilder.Elements;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Statements
{
    public abstract class Accesor : Statement, IAccessModifiable
    {
        private const string snippet = "{0}{1}";
        private readonly LiteralCode name;
        private readonly Statement statement;

        public AccessModifier AccessModifier { get; set; }

        protected Accesor(string name)
            : this(name, new SemicolonStatement(NullCode.Instance))
        {
        }

        protected Accesor(string name, Statement statement)
        {
            this.statement = statement;
            this.name = new LiteralCode(name);
        }

        public override void Render(ICodeWriter renderer)
        {
            if(AccessModifier != null)
            {
                renderer.Write("{0} ", AccessModifier);
            }
            renderer.Write(snippet, name, statement);
        }

        public static Accesor Set(Statement statement)
        {
            return new SetAccesor(statement);
        }

        public static Accesor Get(Statement statement)
        {
            return new GetAccesor(statement);
        }

    }

    public class GetAccesor : Accesor
    {
        private const string getName = "get";

        public static readonly GetAccesor Empty = new GetAccesor();

        protected GetAccesor()
            : base(getName)
        {
        }

        public GetAccesor(Statement statement)
            : base(getName, statement)
        {
        }
    }

    public class SetAccesor : Accesor
    {
        private const string setName = "set";

        public static readonly SetAccesor Empty = new SetAccesor();

        public SetAccesor()
            : base(setName)
        {
        }

        public SetAccesor(Statement statement)
            : base(setName, statement)
        {
        }
    }
}