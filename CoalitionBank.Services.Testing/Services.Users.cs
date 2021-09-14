using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Infrastructure.GrpcServices.UsersGrpcService;
using Grpc.Net.Client;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Client;
using Xunit;
using Xunit.Abstractions;

namespace CoalitionBank.Services.Testing
{
    public class Services_Users
    {

        private const string userId = "mmiJU7XDY0mfkUJVebOlRg";
        private const string userPK = "global";
        
        private readonly ITestOutputHelper output;

        public Services_Users(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async Task GetUser()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var service = channel.CreateGrpcService<IUsersGrpcService>();
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.GetUser(new GetUserCommand() { Id = userId, PartitionKey = userPK });
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public async Task GetUsers()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var service = channel.CreateGrpcService<IUsersGrpcService>();
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.GetUsers(new GetUsersCommand());
            sw.Stop();
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public async Task CreateUser()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var service = channel.CreateGrpcService<IUsersGrpcService>();

            var entity = new UserDto()
            {
                Firstname = "Test",
                Lastname = "McTester",
                Email = "test.mctester@mail.com",
                Password = "Test123!"
            };
            
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.CreateUser(new CreateUserCommand() { Entity = entity });
            sw.Stop();
            
            
            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public async Task DeleteUser()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var service = channel.CreateGrpcService<IUsersGrpcService>();
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.DeleteUser(new DeleteUserCommand() { Id = userId, PartitionKey = userPK });
            sw.Stop();

            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
        
        [Fact]
        public async Task UpdateUser()
        {
            GrpcClientFactory.AllowUnencryptedHttp2 = true;
            using var channel = GrpcChannel.ForAddress("http://localhost:5001");
            var service = channel.CreateGrpcService<IUsersGrpcService>();

            var userResult = await service.GetUsers(new GetUsersCommand() { PageSize = 1 });

            var user = userResult.Users.First();

            user.Firstname = "Tester";
            
            var sw = new Stopwatch();
            
            sw.Start();
            var result = await service.UpdateUser(new UpdateUserCommand() { Entity = user });
            sw.Stop();

            output.WriteLine($"Stopwatch: {sw.Elapsed.TotalMilliseconds}\n");
            output.WriteLine(JsonConvert.SerializeObject(result));
        }
    }
}