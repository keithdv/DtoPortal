using Example.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.DalConcrete
{
    public class BusinessItemListDal : IBusinessItemListDal
    {
        public List<BusinessItemDto> Fetch()
        {

            var BusinessItemDtos = new List<BusinessItemDto>();

            BusinessItemDtos.Add(new BusinessItemDto() { FetchUniqueID = Guid.NewGuid() });
            BusinessItemDtos.Add(new BusinessItemDto() { FetchUniqueID = Guid.NewGuid() });

            return BusinessItemDtos;
        }

        public List<BusinessItemDto> Fetch(Guid criteria)
        {

            var BusinessItemDtos = new List<BusinessItemDto>();

            BusinessItemDtos.Add(new BusinessItemDto() { FetchUniqueID = Guid.NewGuid(), Criteria = criteria });
            BusinessItemDtos.Add(new BusinessItemDto() { FetchUniqueID = Guid.NewGuid(), Criteria = criteria });

            return BusinessItemDtos;
        }

        public void Update(List<BusinessItemDto> listDtos)
        {
            foreach (var i in listDtos)
            {
                if (i.IsNew)
                {
                    _update(i);
                }
                else if (i.IsChanged) // Should be redundant but just making the point that some metadata is added
                {
                    _insert(i);
                }
            }
        }

        private void _update(BusinessItemDto dto)
        {
            dto.UpdateUniqueID = Guid.NewGuid();
        }

        private void _insert(BusinessItemDto dto)
        {
            dto.UpdateUniqueID = Guid.NewGuid();
        }
    }
}
