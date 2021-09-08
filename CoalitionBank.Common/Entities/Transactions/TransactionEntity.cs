using System;
using CoalitionBank.Common.Attributes;
using CoalitionBank.Common.Helpers;

namespace CoalitionBank.Common.Entities.Transactions
{
    [CosmosContainer("Transactions")]
    public class TransactionEntity : BaseEntity, ITransactionEntity
    {
        public TransactionEntity(string RowKey = null, string PartitionKey = null)
        {
            RowKey = !string.IsNullOrEmpty(RowKey) ? RowKey : UUIDGenerator.Generate();
            PartitionKey = PartitionKey;
        }

        public string SenderAccount { get; set; }
        
        public string ReceiverAccount { get; set; }
        
        public decimal Amount { get; set; }
    }
}