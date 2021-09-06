namespace CoalitionBank.Common.Entities.Transactions
{
    public class TransactionEntity : BaseEntity, ITransactionEntity
    {
        public string SenderAccount { get; set; }
        
        public string ReceiverAccount { get; set; }
        
        public decimal Amount { get; set; }
    }
}