using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortal
{

    /// <summary>
    /// Abstract BO object creating, fetching and updating each other
    /// Also for authorization rules, setting meta data and other things the DataPortal currently does
    /// No longer an abstraction for talking to the application layer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObjectPortal<T> : IObjectPortal<T>
    {

        Func<T> createT;

        public ObjectPortal(Func<T> createT)
        {
            this.createT = createT;
        }

        public T Fetch()
        {

            // This is also where we would inforce create authorization rules

            var result = createT();

            var fetch = result as IObjectPortalHandleFetch;

            if(fetch == null)
            {
                throw new ObjectPortalOperationNotSupportedException("Fetch with no criteria not supported");
            }

            fetch.Fetch();

            return result;

        }

        public T Fetch<C>(C criteria)
        {

            var result = createT();

            var fetch = result as IObjectPortalHandleFetch<C>;

            if (fetch == null)
            {
                throw new ObjectPortalOperationNotSupportedException("Fetch with no criteria not supported");
            }

            fetch.Fetch(criteria);

            return result;

        }

    }


    [Serializable]
    public class ObjectPortalOperationNotSupportedException : Exception
    {
        public ObjectPortalOperationNotSupportedException() { }
        public ObjectPortalOperationNotSupportedException(string message) : base(message) { }
        public ObjectPortalOperationNotSupportedException(string message, Exception inner) : base(message, inner) { }
        protected ObjectPortalOperationNotSupportedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
