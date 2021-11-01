using Mov.Core.Model;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mov.Core.ServiceResponse
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public int? Total { get; set; }
        public bool Success { get; set; }
        public string Errors { get; set; }
    }
}
