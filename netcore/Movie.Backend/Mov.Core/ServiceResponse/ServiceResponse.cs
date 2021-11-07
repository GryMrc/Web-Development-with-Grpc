using Mov.Core.Model;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mov.Core.ServiceResponse
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResponse SuccessfulResponse() => new ServiceResponse { Success = true };

        public static ServiceResponse FailedResponse(string message) => new ServiceResponse { Message = message };
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ServiceResponse<T>: ServiceResponse
    {
        public T Data { get; set; }
        public int? Total { get; set; }
    }
}
