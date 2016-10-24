using DtoPortal;
using Example.Dal;
using ObjectPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Lib
{
    public interface IBusinessItemList : Csla.IBusinessListBase<IBusinessItem>, IDtoPortalHandleDtoList<BusinessItemDto>, IObjectPortalHandleFetch<List<BusinessItemDto>>
    {
    }
}
