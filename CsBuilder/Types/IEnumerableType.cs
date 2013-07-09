using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsBuilder.Types
{
    public class IEnumerableType : GenericType, IComplexType
    {
        private readonly CsType implementationType = new CustomType("List");

        public IEnumerableType(CsType genericArgumentType)
            : base("IEnumerable", genericArgumentType)
        {
        }

        #region IComplexType Members

        public CsType ImplementationType
        {
            get { return implementationType; }
        }

        #endregion
    }
}
