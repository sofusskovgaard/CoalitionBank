using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoalitionBank.Common.Attributes;
using CoalitionBank.Common.Entities;
using CoalitionBank.Data.DatabaseService;
using CoalitionBank.Data.Helpers;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Extensions.Configuration;

namespace CoalitionBank.Data.DataContext
{
    public class DataContext : IDataContext
    {
        private readonly IConfiguration _configuration;
        
        private CosmosClient _client;
        
        private Database _database;

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _client = new CosmosClient(configuration["CosmosDB:EntryPoint"], configuration["CosmosDB:PrimaryKey"]);
            _database = _client.CreateDatabaseIfNotExistsAsync(configuration["CosmosDB:Database"]).Result;
        }

        public async Task<T> Get<T>(string RowKey, string PartitionKey = null) where T : BaseEntity
        {
            T result = null;
            var container = GetContainerFromEntity<T>();

            var query = container.GetItemLinqQueryable<T>()
                .Where(entity => entity.RowKey == RowKey);

            if (!string.IsNullOrEmpty(PartitionKey))
            {
                query = query.Where(entity => entity.PartitionKey == PartitionKey);
            }

            using var feed = query.ToFeedIterator();
            
            while (feed.HasMoreResults && result == null)
            {
                foreach(var item in await feed.ReadNextAsync())
                {
                    result = item;
                }
            }

            return result;
        }
        
        public async Task<IEnumerable<T>> Get<T>(int page = 1, int pageSize = 10) where T : BaseEntity
        {
            List<T> result = new List<T>();
            var container = GetContainerFromEntity<T>();

            var query = container.GetItemLinqQueryable<T>().Skip((page - 1) * pageSize);

            using var feed = query.ToFeedIterator();

            while (feed.HasMoreResults && result.Count != pageSize)
            {
                foreach(var item in await feed.ReadNextAsync())
                {
                    result.Add(item);
                }
            }

            return result;
        }

        public async Task<bool> Delete<T>(T entity) where T : BaseEntity
        {
            var container = GetContainerFromEntity<T>();
            var response = await container.DeleteItemAsync<T>(entity.RowKey, new PartitionKey(entity.PartitionKey));
            return response.StatusCode == HttpStatusCode.OK;
        }

        public async Task<T> Create<T>(T entity) where T : BaseEntity
        {
            var container = GetContainerFromEntity<T>();
            var response = await container.CreateItemAsync(entity, new PartitionKey(entity.PartitionKey));
            return response.Resource;
        }

        public static async Task EnsureDatabaseCreate(IConfiguration configuration)
        {
            using CosmosClient client = new CosmosClient(configuration["CosmosDB:EntryPoint"], configuration["CosmosDB:PrimaryKey"]);
            Database database = await client.CreateDatabaseIfNotExistsAsync(configuration["CosmosDB:Database"]);

            foreach (var entityType in EntityDiscovery.Discover())
            {
                var attr = (CosmosContainer)entityType.GetCustomAttributes(typeof(CosmosContainer), false)
                    .FirstOrDefault();
                await database.CreateContainerIfNotExistsAsync(attr.Name, attr.PartiotionKeyPath);
            }
        }
        
        private Container GetContainerFromEntity<T>() where T : BaseEntity
        {
            var attr = (CosmosContainer)typeof(T).GetCustomAttributes(typeof(CosmosContainer), false)
                .FirstOrDefault();
            return _database.GetContainer(attr.Name);
        }
    }
}