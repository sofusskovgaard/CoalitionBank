using System.Threading.Tasks;
using CoalitionBank.Data.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace CoalitionBank.Services.Users
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
#if DEBUG
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
#else
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
#endif

            await DataContext.EnsureDatabaseCreate(configuration);
            await CreateHostBuilder(args).Build().RunAsync();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}