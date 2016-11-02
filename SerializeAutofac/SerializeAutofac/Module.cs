using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAutofac
{
    public class AutofacModule: Module
    {
        public Func<ILifetimeScope, BO> shouldFail = new Func<ILifetimeScope, BO>((x) => new BO(x.Resolve<IDependencyA>()));

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.Register<IBO>(x =>
            {
                return new BO(x.Resolve<IDependencyA>());
            });


            builder.RegisterType<DependencyA>().As<IDependencyA>();

        }


    }
}
