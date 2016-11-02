using DtoPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Example.Dal
{
    public class BusinessItemDto : DtoBase
    {
        public Guid FetchUniqueID { get; set; }
        public Guid UpdateUniqueID { get; set; }
        public Guid Criteria { get; set; }
    }
}
