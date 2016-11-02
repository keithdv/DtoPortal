using Autofac;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAutofac
{
    class Program
    {
        static void Main(string[] args)
        {

            // Update a serialized object
            // Simulate going to the application server
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            // Client to server
            MemoryStream ms = new MemoryStream();

            serializer.WriteObject(ms, new AutofacModule());

            ms.Seek(0, 0);

            var newModule = (AutofacModule)serializer.ReadObject(ms);

            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterModule(newModule);

            var container = builder.Build();

            var bo = container.Resolve<IBO>();


        }
    }
}
