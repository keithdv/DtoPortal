using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DtoPortal
{
    /// <summary>
    /// Abstract the communication between the BO and the application layer to retrieve
    /// the DTOs. This will allow the application to run in 2tier or 3tier
    /// without changing the BO
    /// Does require the repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDtoPortal<T>
    {

        T Fetch();
        T Fetch<C>(C criteria);
        //IList<I> FetchChildDtos<I>() where I : IDto;
        //I FetchChildDto<I>() where I : IDto;
        void Update(T dto);
    }
}
