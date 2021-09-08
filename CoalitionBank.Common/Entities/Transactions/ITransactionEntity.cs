using System;

namespace CoalitionBank.Common.Entities.Transactions
{
    public interface ITransactionEntity : IBaseEntity
    {
        string SenderAccount { get; set; }
        
        string ReceiverAccount { get; set; }
        
        decimal Amount { get; set; }
    }
}