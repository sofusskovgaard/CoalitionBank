using System.Diagnostics;
using System.Threading.Tasks;
using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.TransactionsService;
using CoalitionBank.Infrastructure.GrpcServices.AccountsGrpcService;
using CoalitionBank.Infrastructure.GrpcServices.TransactionsGrpcService;
using Grpc.Net.Client;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Client;
using Xunit;
using Xunit.Abstractions;

namespace CoalitionBank.Services.Testing
{
    public class Services_Transactions
    {
        private const string userId = "mmiJU7XDY0mfkUJVebOlRg";
        private const string userPK = "global";

        private const string firstAccId = "wrUuRW8l0OeXh98FxoqQ";
        private const string firstAccPK = "mmiJU7XDY0mfkUJVebOlRg";
        
        private const string secondAccId = "kVl6lG4IbU6ddwdUy7EjFw";
        private const string secondAccPK = "mmiJU7XDY0mfkUJVebOlRg";
        
        private readonly ITestOutputHelper output;

        public Services_Transactions(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public async Task GetTransaction()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5002");
            var service = channel.CreateGrpcService<ITransactionsGrpcService>();
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.GetTransaction(new GetTransactionCommand() { Id = "", PartitionKey = "" });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public async Task GetTransactions()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5002");
            var service = channel.CreateGrpcService<ITransactionsGrpcService>();
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.GetTransactions(new GetTransactionsCommand() { PartitionKey = firstAccId });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public async Task CreateTransaction()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5002");
            var service = channel.CreateGrpcService<ITransactionsGrpcService>();
            var sw = new Stopwatch();

            var dto = new TransactionDto()
            {
                SenderAccount = firstAccId,
                ReceiverAccount = secondAccId,
                Amount = 69.75M
            };
            
            sw.Start();
            var result = await service.CreateTransaction(new CreateTransactionCommand() { Entity = dto });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}