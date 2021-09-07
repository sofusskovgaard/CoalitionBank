using System;
using System.Threading.Tasks;
using CoalitionBank.Data.DataContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace CoalitionBank.Services.Users
{
    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var isDevelopment = environment == Environments.Development;
            
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console(theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            var configuration = new ConfigurationBuilder();

            if (isDevelopment)
            {
                Log.Information("Getting development configuration for seeder.");
                configuration.AddJsonFile("appsettings.Development.json");
            }
            else
            {
                Log.Information("Getting production configuration for seeder.");
                configuration.AddJsonFile("appsettings.json");
            }
            
            Log.Information("Ensuring database created");
            await DataContext.EnsureDatabaseCreate(configuration.Build());
            
            try
            {
                Log.Information("Starting web host");
                await CreateHostBuilder(args).Build().RunAsync();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}