using System.Linq;

namespace CsBuilder.Types
{
    public class DictionaryType : GenericType, IComplexType
    {
        public DictionaryType(CsType keyType, CsType valueType)
            : base("IDictionary", keyType, valueType)
        {
        }

        #region IComplexType Members

        public CsType ImplementationType
        {
            get 
            {
                return new GenericType("Dictionary", GenericArgumentTypes.ToArray());
            }
        }

        #endregion
    }
}