#region [ using ]

using CsBuilder.Elements;
using CsBuilder.Formatters;

#endregion

namespace CsBuilder.Types
{
    public abstract class CsType : ICode
    {
        public static readonly CsType Int = new IntType();
        public static readonly CsType String = new StringType();
        public static readonly CsType Bool = new BoolType();
        public static readonly CsType DateTime = new DateTimeType();
        public static readonly CsType Void = new VoidType();
        protected readonly NameElement nameElement;
        protected readonly LiteralCode name;

        protected CsType(string name)
        {
            this.name = new LiteralCode(name);
            nameElement = new NameElement(name);
        }

        #region ICode Members

        public virtual void Render(ICodeWriter renderer)
        {
            renderer.Write("{0}", name);
        }

        #endregion

        public ListType AsList()
        {
            return new ListType(this);
        }

        public NullableType AsNullable()
        {
            return new NullableType(this);
        }

        public NameElement GetName()
        {
            return nameElement;
        }

        #region Nested type: BoolType

        private class BoolType : CsType
        {
            public BoolType()
                : base("bool")
            {
            }
        }

        #endregion

        #region Nested type: IntType

        private class IntType : CsType
        {
            public IntType()
                : base("int")
            {
            }
        }

        #endregion

        #region Nested type: StringType

        private class StringType : CsType
        {
            public StringType()
                : base("string")
            {
            }
        }

        #endregion

        #region Nested type: DateTimeType

        private class DateTimeType : CsType
        {
            public DateTimeType()
                : base("DateTime")
            {
            }
        }

        #endregion

        #region Nested type: VoidType

        private class VoidType : CsType
        {
            public VoidType()
                : base("void")
            {
            }
        }

        #endregion
    }
}