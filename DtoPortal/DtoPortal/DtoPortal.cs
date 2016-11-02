using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using System.IO;
using System.Runtime.Serialization;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;

namespace DtoPortal
{

    /// <summary>
    /// Abstract the communication between the BO and the application layer to retrieve
    /// the DTOs. This will allow the application to run in 2tier or 3tier
    /// without changing the BO
    /// Does require the repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DtoPortal<T> : IDtoPortal<T>
        where T : IDto
    {

        ILifetimeScope scope;
        private DtoPortalUpdateManager updateManager;

        /// <summary>
        /// Server-side implementation
        /// Would not use ILifetimeScope in final implementation
        /// </summary>
        /// <param name="fetchDto"></param>
        /// <param name="scope"></param>
        public DtoPortal(ILifetimeScope scope)
        {
            this.scope = scope;
            updateManager = scope.Resolve<DtoPortalUpdateManager>();
        }


        public T Fetch()
        {

            return scope.Resolve<IDtoPortalHandleFetch<T>>().Fetch();
        }

        public T Fetch<C>(C criteria)
        {

            if (!scope.IsRegistered<IDtoPortalHandleFetch<C, T>>())
            {
                throw new DtoPortalDalNotRegisteredException();
            }

            var dal = scope.Resolve<IDtoPortalHandleFetch<C, T>>();


            return dal.Fetch(criteria);

        }

        public void Update(T dto)
        {
            if (!scope.IsRegistered<IDtoPortalHandleUpdate<T>>())
            {
                throw new DtoPortalDalNotRegisteredException();
            }

            var dal = scope.Resolve<IDtoPortalHandleUpdate<T>>();

            // Update a serialized object
            // Simulate going to the application server
            NetDataContractSerializer serializer = new NetDataContractSerializer();

            // Client to server
            MemoryStream ms = new MemoryStream();

            serializer.WriteObject(ms, dto);

            ms.Seek(0, 0);

            var newDto = (T)serializer.ReadObject(ms);

            dal.Update(newDto);

            // Server to client
            ms = new MemoryStream();

            serializer.WriteObject(ms, newDto);

            ms.Seek(0, 0);

            // Context get's send to DtoBase.OnDeserialized
            // So that as each Dto is deserialized we send it
            // to the BO that created the corresponding BO
            serializer.Context = new StreamingContext(StreamingContextStates.CrossMachine, updateManager);

            var returnDto = (T)serializer.ReadObject(ms);



        }

        //public IList<I> FetchChildDtos<I>() where I :IDto
        //{

        //    if (!scope.IsRegistered<IHandleDtoPortalList<I>>())
        //    {
        //        throw new DtoPortalDalNotRegisteredException();
        //    }

        //    var bo = scope.Resolve<IHandleDtoPortalList<I>>();

        //    return bo.CreateDtos();

        //}

        //public I FetchChildDto<I>() where I : IDto
        //{

        //    if (!scope.IsRegistered<IHandleDtoPortal<I>>())
        //    {
        //        throw new DtoPortalDalNotRegisteredException();
        //    }

        //    var bo = scope.Resolve<IHandleDtoPortal<I>>();

        //    var dto = bo.CreateDto();


        //    var metaData = bo as Csla.IBusinessBase;

        //    dto.IsNew = metaData.IsNew;
        //    dto.IsChanged = metaData.IsDirty;

        //    updateManager.AddObjectReference(dto, bo);

        //    return dto;

        //}
    }
    

    [Serializable]
    public class DtoPortalDalNotRegisteredException : Exception
    {
        public DtoPortalDalNotRegisteredException() { }
        public DtoPortalDalNotRegisteredException(string message) : base(message) { }
        public DtoPortalDalNotRegisteredException(string message, Exception inner) : base(message, inner) { }
        protected DtoPortalDalNotRegisteredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

   

}
