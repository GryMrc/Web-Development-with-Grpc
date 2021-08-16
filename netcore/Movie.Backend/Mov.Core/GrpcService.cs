using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Mov.Core
{
    public static class GrpcService
    {
        public static IEndpointRouteBuilder MapModuleServices(this IEndpointRouteBuilder builder)
        {
            foreach (System.Reflection.TypeInfo typeInfo in System.Reflection.Assembly.GetEntryAssembly()?.DefinedTypes)
            {
                if (typeInfo.ImplementedInterfaces.Contains(typeof(IBase)))
                {
                    var mapGrpcServiceMethod = typeof(GrpcEndpointRouteBuilderExtensions).GetMethod("MapGrpcService");
                    mapGrpcServiceMethod.MakeGenericMethod(typeInfo).Invoke(builder, new[] { builder });
                }
            }
            return builder;
        }
        //public static IServiceCollection AddGrpcServiceClients(this IServiceCollection services, string url)
        //{
        //    ClientFactory clientFactory = ClientFactory.Create(BinderConfiguration.Create(binder: new Class3()));
        //    AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        //    var serviceProvider = services.BuildServiceProvider();
        //    var interceptor = serviceProvider.GetRequiredService<Class4>();
        //    var channel = GrpcChannel.ForAddress(url);
        //    var invoker = channel.Intercept((metadata) => serviceProvider.GetRequiredService<Class5>().AddCallContext(metadata)).
        //        Intercept(interceptor);
        //    foreach (string contractLibraryFile in Directory.GetFiles(AppContext.BaseDirectory, "Mov.ServicesContrats.dll"))
        //    {
        //        var contractAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(contractLibraryFile);
        //        foreach (var contractType in contractAssembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(ServiceContractAttribute), false).Length > 0))

        //        {
                 
        //            var createGrpcServiceMethod = typeof(GrpcClientFactory).GetMethod("CreateGrpcService", new[] { typeof(Grpc.Core.CallInvoker), typeof(ClientFactory) });
        //            var serviceClient = createGrpcServiceMethod.MakeGenericMethod(contractType).Invoke(invoker, new object[] { invoker, clientFactory });
        //            services.AddSingleton(contractType, serviceClient);
        //        }
        //    }
        //    return services;
        //}

        public static IServiceCollection addservicegrp(this IServiceCollection services,string url)
        {
            ClientFactory clientFactory = ClientFactory.Create(BinderConfiguration.Create(binder: new GenericBinder()));
                AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport",true);

                var channel = GrpcChannel.ForAddress(url);
                foreach (string contractLibraryFile in Directory.GetFiles(AppContext.BaseDirectory, "Mov.ServicesContrats.dll"))
                {
                    var contractAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(contractLibraryFile);
                    foreach (var contractType in contractAssembly.GetTypes().Where(t => t.GetCustomAttributes(typeof(ServiceContractAttribute), false).Length > 0))
                    {
                        var createGrpcServiceMethod = typeof(GrpcClientFactory).GetMethod("CreateGrpcService", new[] { typeof(Grpc.Core.ChannelBase), typeof(ClientFactory) });
                        var serviceClient = createGrpcServiceMethod.MakeGenericMethod(contractType).Invoke(channel, new object[] { channel, clientFactory });
                        services.AddSingleton(contractType, serviceClient);
                    }
                }
            
            return services;
        }
      
    }
}
