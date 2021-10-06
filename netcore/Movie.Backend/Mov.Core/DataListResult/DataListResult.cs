using Mov.Core.Model;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core.DataListResult
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class DataListResult<T> : DataModel
    {
        public IEnumerable<T> dataList { get; set; }
        public int Total { get; set; }
        public string Error { get; set; }
    }
}
