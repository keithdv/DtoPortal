using DtoPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Dal
{
    public class RootDto : DtoBase
    {


        public List<BusinessItemDto> BusinessItemDtos { get; set; }
    }
}
