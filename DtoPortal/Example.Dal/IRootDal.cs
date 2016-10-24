using DtoPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Dal
{
    public interface IRootDal : IDtoPortalHandleFetch<RootDto>, IDtoPortalHandleFetch<Guid, RootDto>, IDtoPortalHandleUpdate<RootDto>
    {


    }
}
