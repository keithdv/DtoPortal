using Csla;
using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ObjectPortal;
using Example.Dal;
using DtoPortal;

namespace Example.Lib
{
    [Serializable]
    public class Root : DtoBusinessBase<Root>, IRoot, IHandleObjectPortalFetch, IHandleObjectPortalFetch<Guid>
    {

        public static DependencyPropertyInfo<IObjectPortal<IBusinessItemList>> BusinessItemListPortalProperty = new DependencyPropertyInfo<IObjectPortal<IBusinessItemList>>(nameof(BusinessItemListPortal));

        public IObjectPortal<IBusinessItemList> BusinessItemListPortal
        {
            get { return GetDependencyProperty(BusinessItemListPortalProperty); }
        }

        public static DependencyPropertyInfo<IDtoPortal<RootDto>> DtoPortalProperty = new DependencyPropertyInfo<IDtoPortal<RootDto>>(nameof(DtoPortal));

        public IDtoPortal<RootDto> DtoPortal
        {
            get { return GetDependencyProperty(DtoPortalProperty); }
        }

        
        public static readonly PropertyInfo<IBusinessItemList> BusinessItemListProperty = RegisterProperty<IBusinessItemList>(c => c.BusinessItemList);
        public IBusinessItemList BusinessItemList
        {
            get { return GetProperty(BusinessItemListProperty); }
            set { SetProperty(BusinessItemListProperty, value); }
        }

        void IHandleObjectPortalFetch.Fetch()
        {

            var rootDto = DtoPortal.Fetch();

            BusinessItemList = BusinessItemListPortal.Fetch(rootDto.BusinessItemDtos);

        }

        public void Fetch(Guid criteria)
        {
            var rootDto = DtoPortal.Fetch(criteria);

            BusinessItemList = BusinessItemListPortal.Fetch(rootDto.BusinessItemDtos);
        }

        public void SaveDto()
        {

            // Gather the DTO tree
            // Keep hooks in place so that I can
            // send back the DTO to it's "RIGHTFUL OWNER"

            var dto = new RootDto();

            dto.BusinessItemDtos = BusinessItemList.CreateDtos();

            DtoPortal.Update(dto);



        }
    }
}
