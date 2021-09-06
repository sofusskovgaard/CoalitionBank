namespace CoalitionBank.Common.DataTransportObjects.Transactions
{
    public class TransactionDto : BaseDto
    {
        public string SenderAccount { get; set; }
        
        public string ReceiverAccount { get; set; }
        
        public decimal Amount { get; set; }
    }
}