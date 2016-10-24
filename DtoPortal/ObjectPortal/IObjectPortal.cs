using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortal
{
    public interface IObjectPortal<T>
    {

        T Fetch();
        T Fetch<C>(C criteria);
    }
}
