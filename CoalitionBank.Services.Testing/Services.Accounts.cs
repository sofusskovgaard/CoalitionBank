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
        private const string userId = "mmiJU7XDY0mfkUJVebOlRg";
        private const string userPK = "global";

        private const string firstAccId = "wrUuRW8l0OeXh98FxoqQ";
        private const string firstAccPK = "mmiJU7XDY0mfkUJVebOlRg";
        
        private const string secondAccId = "kVl6lG4IbU6ddwdUy7EjFw";
        private const string secondAccPK = "mmiJU7XDY0mfkUJVebOlRg";
        
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
            var result = await service.GetAccount(new GetAccountCommand { Id = firstAccId, PartitionKey = firstAccPK });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task GetAccounts()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.GetAccounts(new GetAccountsCommand() { PartitionKey = userId });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task CreateAccount()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();

            var dto = new AccountDto
            {
                Title = "Opsparing konto",
                PartitionKey = userId,
                Balance = 0,
                Owner = userId,
                UsersWithAccess = new[] { userId }
            };

            sw.Start();
            var result = await service.CreateAccount(new CreateAccountCommand { Entity = dto });
            sw.Stop();
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }

        [Fact]
        public async Task DeleteAccount()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();

            sw.Start();
            var result = await service.DeleteAccount(new DeleteAccountCommand { Id = firstAccId, PartitionKey = firstAccPK });
            sw.Stop();

            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result.Success));
        }

        [Fact]
        public async Task UpdateAccountBalance()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5003");
            var service = channel.CreateGrpcService<IAccountsGrpcService>();
            var sw = new Stopwatch();

            sw.Start();
            var result = await service.UpdateAccountBalance(new UpdateAccountBalanceCommand { Id = secondAccId, PartitionKey = secondAccPK });
            sw.Stop();

            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}