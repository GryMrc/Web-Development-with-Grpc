using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov.ViewModels.ServiceResponse
{
    public class ServiceResponse
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

    public class ServiceResponse<T> : ServiceResponse
    {
        public T Data { get; set; }
    }
}
