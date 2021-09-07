using CoalitionBank.Common.DataTransportObjects.Transactions;
using CoalitionBank.Common.Entities.Transactions;

namespace CoalitionBank.API.Types
{
    public class TransactionType : BaseType<TransactionDto>
    {
        public TransactionType()
        {
            Field(x => x.SenderAccount, type: typeof(UserType));
            Field(x => x.ReceiverAccount, type: typeof(UserType));
            Field(x => x.Amount);
        }
    }
}