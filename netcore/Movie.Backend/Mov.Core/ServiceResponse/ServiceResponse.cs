using Mov.Core.Model;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mov.Core.ServiceResponse
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ServiceResponse: DataModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static ServiceResponse SuccessfulResponse()
        {
            return new ServiceResponse { Success = true };
        }

        public static ServiceResponse FailedResponse(string message)
        {
            return new ServiceResponse { Success = false, Message = message };
        }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
