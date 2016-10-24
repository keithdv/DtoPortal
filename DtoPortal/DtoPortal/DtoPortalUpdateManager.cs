using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoPortal
{
    public class DtoPortalUpdateManager
    {

        public DtoPortalUpdateManager()
        {
            ObjectReferences = new Dictionary<uint, IObjectReference>();
            Counter = 1;
        }

        public interface IObjectReference
        {
            void UpdatedDto(IDto dto);
        }
        public class ObjectReference<T> : IObjectReference
            where T : IDto
        {
            public T Dto { get; set; }
            public IDtoPortalHandleDto<T> BO { get; set; }

            public void UpdatedDto(IDto dto)
            {
                BO.UpdatedDto((T) dto);
            }
        }

        public Dictionary<uint, IObjectReference> ObjectReferences { get; set; }

        private uint Counter;

        public void AddObjectReference<T>(T dto, IDtoPortalHandleDto<T> bo) where T : IDto
        {
            Counter++;
            ObjectReferences.Add(Counter, new ObjectReference<T>() { Dto = dto, BO = bo });
            dto.UpdateKey = Counter;
        }

        public void NewDto<T>(T newDto) where T : IDto
        {
            if (ObjectReferences.ContainsKey(newDto.UpdateKey))
            {
                var or = ObjectReferences[newDto.UpdateKey];
                or.UpdatedDto(newDto);
            }
        }

        public T CreateDto<T>(IBusinessBase bo) where T : IDto
        {
            var handle = bo as IDtoPortalHandleDto<T>;

            var dto = handle.CreateDto();

            dto.IsNew = bo.IsNew;
            dto.IsChanged = bo.IsDirty;

            AddObjectReference(dto, handle);

            return dto;

        }

        //public IList<T> CreateDtos<T, L>(L list) where T : IDto
        //{
        //    var handle = list as IDtoPortalHandleDtoList<T>;

        //    var result = handle.CreateDtos();

        //    //foreach (var r in result)
        //    //{
        //    //    AddObjectReference(r, list);
        //    //}

        //    return result;

        //}

    }
}
