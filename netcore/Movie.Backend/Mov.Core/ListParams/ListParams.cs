using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.ListParams
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ListParams
    {
        public int pageSize { get; set; }
        public int page { get; set; }
    }
}
