using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoPortal
{

    
    public interface IDtoPortalHandleDto<T>
        where T : IDto
    {

        T CreateDto();

        void UpdatedDto(T dto);

    }

    public interface IDtoPortalHandleDtoList<T>
    where T : IDto
    {


        List<T> CreateDtos();
        

    }

    public interface IDtoPortalHandleFetch<T>
    {
        T Fetch();
    }

    public interface IDtoPortalHandleFetch<C, T>
    {

        T Fetch(C criteria);

    }

    public interface IDtoPortalHandleUpdate<T>
        where T : IDto
    {
        void Update(T dto);
    }

    public interface IDtoPortalHandleUpdateList<T>
        where T : IDto
    {
        void Update(List<T> listDtos);
    }

}
