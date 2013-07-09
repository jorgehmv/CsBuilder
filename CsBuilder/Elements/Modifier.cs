#region [ using ]

#endregion

namespace CsBuilder.Elements
{
    public class Modifier : CodeElement
    {
        public static readonly Modifier Virtual = new Modifier("virtual");
        public static readonly Modifier Override = new Modifier("override");
        public static readonly Modifier Static = new Modifier("static");
        public static readonly Modifier ReadOnly = new Modifier("readonly");

        private Modifier(string name)
            : base(name)
        {
        }
    }
}