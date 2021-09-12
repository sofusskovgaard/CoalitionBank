using System.Diagnostics;
using System.Threading.Tasks;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using Grpc.Net.Client;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Client;
using Xunit;
using Xunit.Abstractions;

namespace CoalitionBank.Services.Testing
{
    public class Services_Accounts
    {
        private readonly ITestOutputHelper output;

        public Services_Accounts(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task GetAccount()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();
            sw.Start();
            var result = await service.GetAccount(new GetAccountCommand() { Id = "", PartitionKey = "" });
            sw.Stop();
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result.Entity));
        }
        
        [Fact]
        public async Task GetAccounts()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();
            sw.Start();
            var result = await service.GetAccounts(new GetAccountsCommand());
            sw.Stop();
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result.Entities));
        }
        
        [Fact]
        public async Task CreateAccount()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();

            var dto = new AccountDto() { PartitionKey = "kaV7n0Jkk0y7VJpsiFKog", Title = "Løn konto", Balance = 0, Owner = "kaV7n0Jkk0y7VJpsiFKog", UsersWithAccess = new []{ "kaV7n0Jkk0y7VJpsiFKog" } };
            
            sw.Start();
            var result = await service.CreateAccount(new CreateAccountCommand() { Entity = dto });
            sw.Stop();
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result.Entity));
        }
        
        [Fact]
        public async Task DeleteAccount()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();

            sw.Start();
            var result = await service.DeleteAccount(new DeleteAccountCommand() { Id = "lJfyKisRv0aIUNhOC3qGg", PartitionKey = "kaV7n0Jkk0y7VJpsiFKog" });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result.Success));
        }
    }
}