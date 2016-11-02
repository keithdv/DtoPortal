using DtoPortal;
using Example.Dal;
using ObjectPortal;
using System;

namespace Example.Lib
{
    public interface IBusinessItem : Csla.IBusinessBase, IHandleObjectPortalFetch<BusinessItemDto>, IHandleDtoPortal<BusinessItemDto>
    {

        Guid Criteria { get; set; }
        Guid ScopeID { get; set; }
        Guid FetchID { get; set; }
        Guid UpdatedID { get; set; }
    }
}