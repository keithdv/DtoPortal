using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ObjectPortal;
using Example.Dal;
using DtoPortal;

namespace Example.Lib
{
    [Serializable]
    public class BusinessItemList : Csla.BusinessListBase<BusinessItemList, IBusinessItem>, IBusinessItemList
    {

        IObjectPortal<IBusinessItem> itemPortal;
        Lazy<DtoPortalUpdateManager> updateManager;

        public BusinessItemList(IObjectPortal<IBusinessItem> itemPortal, Lazy<DtoPortalUpdateManager> updateManager)
        {
            this.itemPortal = itemPortal;
            this.updateManager = updateManager;
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
                    dtos.Add(updateManager.Value.CreateDto<BusinessItemDto>(item));
                }
            }

            return dtos;

        }

        public void Fetch(List<BusinessItemDto> criteria)
        {

            foreach (var i in criteria)
            {
                Add(itemPortal.Fetch(i));
            }

        }

    }
}
