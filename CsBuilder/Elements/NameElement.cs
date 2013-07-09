namespace CsBuilder.Elements
{
    public class NameElement : CodeElement
    {
        public NameElement(string name)
            : base(string.Format("@{0}", name))
        {
        }

        public string Name
        {
            get { return name; }
        }
    }
}