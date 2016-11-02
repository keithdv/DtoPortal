using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace ObjectPortal
{
    public class DependencyManager
    {

        public DependencyManager(ILifetimeScope scope)
        {
            this.scope = scope;

        }

        [NonSerialized]
        Dictionary<Type, object> dependencies = new Dictionary<Type, object>();

        [NonSerialized]
        ILifetimeScope scope;

        public DP GetPropertyValue<DP>(IDependencyPropertyInfo<DP> propertyInfo)
        {

            if (!dependencies.ContainsKey(typeof(DP)))
            {
                dependencies.Add(typeof(DP), scope.Resolve(typeof(DP)));
            }

            return (DP)dependencies[typeof(DP)];

        }

    }
}
