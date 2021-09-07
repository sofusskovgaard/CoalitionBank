using System;
using System.Reflection;
using AutoMapper.Configuration;
using CoalitionBank.Common.DataTransportObjects;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.Helpers.Markers;
using CoalitionBank.Handlers.Helpers.Utilities;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProtoBuf.Grpc.Server;
using Serilog;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace CoalitionBank.Services.Users
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Serilog
            services.AddSingleton(Log.Logger);
            
            // add automapper functionality.
            services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetAssembly(typeof(BaseDto))));
            
            // protobuf-net.grpc.
            services.AddCodeFirstGrpc();
            
            // add other services.
            services.AddSingleton<IDataContext>(provider => new DataContext(provider.GetRequiredService<IConfiguration>(), provider.GetRequiredService<ILogger>()));
            
            // add command handlers.
            services.AddCommandHandlers<IGrpcCommandHandlerMarker>();

            // newtonsoft bullshit
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
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