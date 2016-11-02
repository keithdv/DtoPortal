using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAutofac
{
    public interface IBO { string Name { get; set; } }

    public class BO : IBO
    {
        public BO (IDependencyA dep)
        {

        }
        public string Name { get; set; }
    }


}
