using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mov.Core;
using Mov.Core.InterCeptor;
using Mov.Mutual;
using ProtoBuf.Grpc.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mov.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            Action<DbContextOptionsBuilder> contextOptions = (options) =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            };
            services
                   .AddDbContext<ApplicationDbContext>(contextOptions)
                   .AddCodeFirstGrpc(options =>
                   {
                       options.Interceptors.Add<ExceptionInterceptor>();
                       options.EnableDetailedErrors = true;
                   });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapModuleServices();
                endpoints.MapGet("/", async context =>
                {

                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
