using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using ObjectPortal;
using Example.Dal;
using DtoPortal;

namespace Example.Lib
{
    [Serializable]
    public class BusinessItemList : DtoBusinessListBase<BusinessItemList, IBusinessItem>, IBusinessItemList
    {


        public static DependencyPropertyInfo<IObjectPortal<IBusinessItem>> ItemPortalProperty = new DependencyPropertyInfo<IObjectPortal<IBusinessItem>>(nameof(ItemPortal));

        public IObjectPortal<IBusinessItem> ItemPortal
        {
            get { return GetDependencyProperty(ItemPortalProperty); }
        }

        public static DependencyPropertyInfo<DtoPortalUpdateManager> DtoPortalUpdateManagerProperty = new DependencyPropertyInfo<DtoPortalUpdateManager>(nameof(DtoPortalUpdateManager));

        public DtoPortalUpdateManager DtoPortalUpdateManager
        {
            get { return GetDependencyProperty(DtoPortalUpdateManagerProperty); }
        }

        public List<BusinessItemDto> CreateDtos()
        {

            var dtos = new List<BusinessItemDto>();

            foreach (var item in this)
            {
                // This part I don't like.
                // Need to keep track of which business object
                // created which DTO using Dto.UpdatedKey
                // Need to add a middle man to do this
                if (item.IsDirty)
                {
                    dtos.Add(DtoPortalUpdateManager.CreateDto<BusinessItemDto>(item));
                }
            }

            return dtos;

        }

        public void Fetch(List<BusinessItemDto> criteria)
        {

            foreach (var i in criteria)
            {
                Add(ItemPortal.Fetch(i));
            }

        }

    }
}
