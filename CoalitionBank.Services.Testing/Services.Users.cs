using System.Diagnostics;
using System.Threading.Tasks;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;
using Xunit;
using Xunit.Abstractions;

namespace CoalitionBank.Services.Testing
{
    public class Services_Users
    {
        private readonly ITestOutputHelper output;

        public Services_Users(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task Services_Users_Greet()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var service = channel.CreateGrpcService<IUsersGrpcService>();
            var sw = new Stopwatch();
            sw.Start();
            var result = await service.GetUser(new GetUserCommand() { RowKey = "balls", PartitionKey = "balls" });
            sw.Stop();
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}");
            output.WriteLine(result.User.RowKey);
        }
    }
}