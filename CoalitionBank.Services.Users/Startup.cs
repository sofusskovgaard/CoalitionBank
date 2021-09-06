using System.Reflection;
using CoalitionBank.Common.DataTransportObjects;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using CoalitionBank.Handlers.Helpers.Utilities;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;

namespace CoalitionBank.Services.Users
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCodeFirstGrpc();

            services.AddCommandHandlers<IGrpcCommandHandlerMarker>();

            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(BaseDto))));
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
                endpoints.MapGrpcService<UsersGrpcService>();
                endpoints.MapCodeFirstGrpcReflectionService();
            });
        }
    }
}