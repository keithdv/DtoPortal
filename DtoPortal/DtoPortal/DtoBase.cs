using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DtoPortal
{

    public interface IDto
    {
        bool IsNew { get; set; }
        bool IsChanged { get; set; }
        uint UpdateKey { get; set; }
    }

    public class DtoBase : IDto
    {
        public bool IsNew { get; set; }
        public bool IsChanged { get; set; }

        public uint UpdateKey { get; set; }

        [OnDeserialized()]
        public void OnDeserialized(StreamingContext context)
        {

            var updateManager = context.Context as DtoPortalUpdateManager;

            if(updateManager != null)
            {
                // Reconnect this new dto to the original business object using DtoBase.UpdateKey
                // within the DtoPortalUpdateManager
                updateManager.NewDto(this);
            }

        }
    }
}
