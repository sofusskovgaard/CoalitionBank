using System.Collections.Generic;
using System.Threading.Tasks;
using CoalitionBank.Common.Entities;

namespace CoalitionBank.Data.DataContext
{
    public interface IDataContext
    {
        Task<T> Get<T>(string Id, string PartitionKey = null) where T : BaseEntity;
        
        Task<IEnumerable<T>> Get<T>(IEnumerable<string> Id, string PartitionKey = null) where T : BaseEntity;
        
        Task<IEnumerable<T>> Get<T>(string PartitionKey = null, int page = 1, int pageSize = 10) where T : BaseEntity;
        
        Task<IEnumerable<T>> GetFrom<T>(string Id, string PartitionKey) where T : BaseEntity;

        Task<bool> Delete<T>(string Id, string PartitionKey) where T : BaseEntity;

        Task<T> Create<T>(T entity) where T : BaseEntity;
        Task<IEnumerable<T>> CreateMany<T>(IEnumerable<T> entities) where T : BaseEntity;
        
        Task<T> Update<T>(T entity) where T : BaseEntity;
    }
}