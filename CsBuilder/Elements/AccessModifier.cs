#region [ using ]

#endregion

namespace CsBuilder.Elements
{
    public class AccessModifier : CodeElement
    {
        public static readonly AccessModifier Private = new AccessModifier("private");
        public static readonly AccessModifier Protected = new AccessModifier("protected");
        public static readonly AccessModifier Public = new AccessModifier("public");
        public static readonly AccessModifier ProtectedInternal = new AccessModifier("protected internal");

        private AccessModifier(string name)
            : base(name)
        {
        }
    }
}