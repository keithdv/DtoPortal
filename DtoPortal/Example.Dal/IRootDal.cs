using DtoPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Example.Dal
{
    public interface IRootDal : IDtoPortalHandleFetch<RootDto>, IDtoPortalHandleFetch<Guid, RootDto>, IDtoPortalHandleUpdate<RootDto>
    {


    }
}
