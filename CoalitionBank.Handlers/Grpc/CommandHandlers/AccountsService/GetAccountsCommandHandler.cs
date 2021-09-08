using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Accounts;
using CoalitionBank.Common.Entities.Accounts;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.AccountsService;
using CoalitionBank.Handlers.Grpc.Commands.AccountsService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.AccountsService
{
    public class GetAccountsCommandHandler : GrpcCommandHandler<GetAccountsCommand, GetAccountsCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;
        
        public GetAccountsCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetAccountsCommandResult> Invoke(GetAccountsCommand command)
        {
            var entities = await _dataContext.Get<AccountEntity>(command.PartitionKey, command.Page, command.PageSize);
            var dtos = _mapper.Map<IEnumerable<AccountDto>>(entities);
            return new GetAccountsCommandResult() { Entities = dtos };
        }
    }
}