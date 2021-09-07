using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using CoalitionBank.Common.Attributes;
using CoalitionBank.Common.Entities;
using CoalitionBank.Data.Helpers;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace CoalitionBank.Data.DataContext
{
    public class DataContext : IDataContext
    {
        private static readonly CosmosLinqSerializerOptions _serializerOptions =
            new() { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase };

        private static readonly CosmosClientOptions _clientOptions = new()
        {
            Serializer = new CosmosSystemTextJsonSerializer(
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    IgnoreNullValues = true,
                    IgnoreReadOnlyFields = true
                })
        };

        private readonly CosmosClient _client;

        private readonly Database _database;
        
        private readonly IConfiguration _configuration;

        private readonly ILogger _logger;

        public DataContext(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
            
            _client = CreateClient();
            _database = _client.CreateDatabaseIfNotExistsAsync(configuration["CosmosDB:Database"]).Result;
        }

        public async Task<T> Get<T>(string Id, string PartitionKey = null) where T : BaseEntity
        {
            T result = null;
            var container = GetContainerFromEntity<T>();

            var query = container.GetItemLinqQueryable<T>(linqSerializerOptions: _serializerOptions)
                .Where(entity => entity.Id == Id);

            if (!string.IsNullOrEmpty(PartitionKey)) query = query.Where(entity => entity.PartitionKey == PartitionKey);

            using var feed = query.ToFeedIterator();

            while (feed.HasMoreResults && result == null)
            {
                var response = await feed.ReadNextAsync();
                _logger.Information($"Charge: {response.RequestCharge}");
                foreach (var item in response)
                    result = item;
            }
            return result;
        }

        public async Task<IEnumerable<T>> Get<T>(string PartitionKey = null, int page = 1, int pageSize = 10) where T : BaseEntity
        {
            var result = new List<T>();
            var container = GetContainerFromEntity<T>();

            IQueryable<T> query = null;

            if (!string.IsNullOrEmpty(PartitionKey))
                query = container.GetItemLinqQueryable<T>(linqSerializerOptions: _serializerOptions).Where(entity => entity.PartitionKey == PartitionKey);

            query = query != null ? query.Skip((page - 1) * pageSize).Take(pageSize) : container.GetItemLinqQueryable<T>(linqSerializerOptions: _serializerOptions).Skip((page - 1) * pageSize).Take(pageSize);

            using var feed = query.ToFeedIterator();

            while (feed.HasMoreResults && result.Count != pageSize)
            {
                var response = await feed.ReadNextAsync();
                _logger.Information($"Charge: {response.RequestCharge}");
                foreach (var item in response)
                    result.Add(item);
            }
            return result;
        }

        public async Task<bool> Delete<T>(string Id, string PartitionKey) where T : BaseEntity
        {
            var container = GetContainerFromEntity<T>();
            var response = await container.DeleteItemAsync<T>(Id, new PartitionKey(PartitionKey));
            _logger.Information($"Charge: {response.RequestCharge}");
            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public async Task<T> Create<T>(T entity) where T : BaseEntity
        {
            var container = GetContainerFromEntity<T>();
            var response = await container.CreateItemAsync(entity, new PartitionKey(entity.PartitionKey));
            _logger.Information($"Charge: {response.RequestCharge}");
            return response.Resource;
        }

        public static async Task EnsureDatabaseCreate(IConfiguration configuration)
        {
            using var client = new CosmosClient(configuration["CosmosDB:EntryPoint"],
                configuration["CosmosDB:PrimaryKey"], _clientOptions);
            Database database = await client.CreateDatabaseIfNotExistsAsync(configuration["CosmosDB:Database"]);

            foreach (var entityType in EntityDiscovery.Discover())
            {
                var attr = (CosmosContainer)entityType.GetCustomAttributes(typeof(CosmosContainer), false)
                    .FirstOrDefault();

                var container = database.DefineContainer(attr.Name, attr.PartiotionKeyPath);

                foreach (var property in entityType.GetProperties().Where(x => x.GetCustomAttribute<CosmosUniqueKey>() != null))
                {
                    container.WithUniqueKey()
                        .Path($"/{char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1)}")
                        .Attach();
                }

                await container.CreateIfNotExistsAsync();
            }
        }

        private CosmosClient CreateClient()
        {
            return new CosmosClient(_configuration["CosmosDB:EntryPoint"], _configuration["CosmosDB:PrimaryKey"],
                _clientOptions);
        }

        private Container GetContainerFromEntity<T>() where T : BaseEntity
        {
            var attr = (CosmosContainer)typeof(T).GetCustomAttributes(typeof(CosmosContainer), false)
                .FirstOrDefault();
            return _database.GetContainer(attr.Name);
        }
    }
}