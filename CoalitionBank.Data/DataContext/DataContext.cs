using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace CoalitionBank.Data.DatabaseService
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _configuration;
        
        private CosmosClient _client;
        private Database _database;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
    }
}