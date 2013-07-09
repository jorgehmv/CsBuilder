#region [ using ]
using System.Linq;
#endregion

namespace CsBuilder.Types
{
    public class ListType : GenericType, IComplexType
    {
        public ListType(CsType genericArgumentType)
            : base("IList", genericArgumentType)
        {
        }

        #region IComplexType Members

        public CsType ImplementationType
        {
            get 
            {
                return new GenericType("List", GenericArgumentTypes.ToArray());
            }
        }

        #endregion
    }
}