namespace CsBuilder.Types
{
    public class CustomType : CsType, IComplexType
    {
        public CustomType(string name)
            : base(name)
        {
        }

        #region IComplexType Members

        public CsType ImplementationType
        {
            get { return this; }
        }

        #endregion
    }
}