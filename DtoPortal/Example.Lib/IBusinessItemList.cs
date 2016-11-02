﻿using DtoPortal;
using Example.Dal;
using ObjectPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Lib
{
    public interface IBusinessItemList : Csla.IBusinessListBase<IBusinessItem>, IHandleDtoPortalList<BusinessItemDto>, IHandleObjectPortalFetch<List<BusinessItemDto>>
    {
    }
}
