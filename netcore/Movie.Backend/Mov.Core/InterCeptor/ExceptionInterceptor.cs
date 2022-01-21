using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Mov.Core.InterCeptor
{
    public class ExceptionInterceptor : Interceptor
    {
        private readonly ILogger<ExceptionInterceptor> _logger;

        public ExceptionInterceptor(ILogger<ExceptionInterceptor> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context);
            }
            catch (Exception exception)
            {
                bool succes = Exceptionhandler.ExceptionHandler.SetException(context.ResponseTrailers, exception);
                if (succes)
                {
                    Metadata entries = new Metadata();
                    throw new RpcException(new Status(StatusCode.Internal, Exceptionhandler.ExceptionHandler.METADATA_KEY),entries);
                }

                throw new RpcException(new Status(StatusCode.Internal, exception.Message));
            }
        }
    }
}
