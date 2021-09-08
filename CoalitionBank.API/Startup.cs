using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoalitionBank.API.Types;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProtoBuf.Grpc.ClientFactory;

namespace CoalitionBank.API
{
    public class Startup
    {

        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }
        
        public IWebHostEnvironment Environment { get; private set; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<GraphSchema>();

            services.AddCodeFirstGrpcClient<IUsersGrpcService>(options =>
            {
                options.Address = new Uri(System.Environment.GetEnvironmentVariable("USERS_SERVICE_URI"));
            });

            services.AddGraphQL((options, provider) =>
                {
                    options.EnableMetrics = Environment.IsDevelopment();
                    var logger = provider.GetRequiredService<ILogger<Startup>>();
                    options.UnhandledExceptionDelegate = ctx => logger.LogError($"{ctx.OriginalException.Message} occurred");
                })
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = Environment.IsDevelopment())
                .AddGraphTypes(typeof(BaseType<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseGraphQL<GraphSchema>();
            app.UseGraphQLPlayground(new PlaygroundOptions());
        }
    }
}