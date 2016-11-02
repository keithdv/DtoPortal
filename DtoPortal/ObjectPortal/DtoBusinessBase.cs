using ObjectPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortal
{
    [Serializable]
    public class DtoBusinessBase<T> : Csla.BusinessBase<T>, IDtoBusinessObject
        where T : DtoBusinessBase<T>
    {
        [NonSerialized]
        private DependencyManager _dependencyManager;

        public DependencyManager DependencyManager
        {
            get { return _dependencyManager; }
        }

        DependencyManager IDtoBusinessObject.DependencyManager
        {
            set { _dependencyManager = value; }
        }
        
        protected DP GetDependencyProperty<DP>(IDependencyPropertyInfo<DP> propertyInfo)
        {
            return DependencyManager.GetPropertyValue(propertyInfo);

        }

    }
}
