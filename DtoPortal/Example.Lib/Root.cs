using Csla;
using System;
using Autofac;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectPortal;
using Example.Dal;
using DtoPortal;

namespace Example.Lib
{
    [Serializable]
    public class Root : Csla.BusinessBase<Root>, IRoot, IObjectPortalHandleFetch, IObjectPortalHandleFetch<Guid>
    {

        IObjectPortal<IBusinessItemList> listPortal;
        IDtoPortal<RootDto> dtoPortal;

        public Root(IDtoPortal<RootDto> dtoPortal, IObjectPortal<IBusinessItemList> listPortal)
        {
            this.listPortal = listPortal;
            this.dtoPortal = dtoPortal;
        }

        public static readonly PropertyInfo<IBusinessItemList> BusinessItemListProperty = RegisterProperty<IBusinessItemList>(c => c.BusinessItemList);
        public IBusinessItemList BusinessItemList
        {
            get { return GetProperty(BusinessItemListProperty); }
            set { SetProperty(BusinessItemListProperty, value); }
        }

        void IObjectPortalHandleFetch.Fetch()
        {

            var rootDto = dtoPortal.Fetch();

            BusinessItemList = listPortal.Fetch(rootDto.BusinessItemDtos);

        }

        public void Fetch(Guid criteria)
        {
            var rootDto = dtoPortal.Fetch(criteria);

            BusinessItemList = listPortal.Fetch(rootDto.BusinessItemDtos);
        }

        public void SaveDto()
        {

            // Gather the DTO tree
            // Keep hooks in place so that I can
            // send back the DTO to it's "RIGHTFUL OWNER"

            var dto = new RootDto();

            dto.BusinessItemDtos = BusinessItemList.CreateDtos();

            dtoPortal.Update(dto);



        }
    }
}
