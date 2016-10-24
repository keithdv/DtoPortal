using DtoPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Dal
{
    public interface IBusinessItemListDal : IDtoPortalHandleUpdateList<BusinessItemDto>
    {

        List<BusinessItemDto> Fetch();
        List<BusinessItemDto> Fetch(Guid criteria);

    }
}
