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
            catch (MovException.MovException weatherException)
            {
                var httpContext = context.GetHttpContext();
                httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                throw new RpcException(new Status(StatusCode.FailedPrecondition, weatherException.Message));
            }
            catch (Exception exception)
            {
                throw new RpcException(new Status(StatusCode.Internal, exception.ToString()));
            }
        }
    }
}
