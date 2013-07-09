namespace CsBuilder.Elements
{
    public class ClassModifier : CodeElement
    {
        public static readonly ClassModifier Abstract = new ClassModifier("abstract");
        public static readonly ClassModifier Sealed = new ClassModifier("sealed");
        public static readonly ClassModifier Empty = new ClassModifier(string.Empty);

        private ClassModifier(string name)
            : base(name)
        {
        }
    }
}