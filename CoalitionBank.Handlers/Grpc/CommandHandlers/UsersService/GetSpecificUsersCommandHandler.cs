using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CoalitionBank.Common.DataTransportObjects.Users;
using CoalitionBank.Common.Entities.Users;
using CoalitionBank.Data.DataContext;
using CoalitionBank.Handlers.Grpc.CommandResults.UsersService;
using CoalitionBank.Handlers.Grpc.Commands.UsersService;
using CoalitionBank.Handlers.Grpc.Helpers;

namespace CoalitionBank.Handlers.Grpc.CommandHandlers.UsersService
{
    public class GetSpecificUsersCommandHandler : GrpcCommandHandler<GetSpecificUsersCommand, GetSpecificUsersCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public GetSpecificUsersCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetSpecificUsersCommandResult> Invoke(GetSpecificUsersCommand command)
        {
            var entities = await _dataContext.Get<UserEntity>(command.Ids, "global");
            var dtos = _mapper.Map<IEnumerable<UserDto>>(entities);
            return new GetSpecificUsersCommandResult() { Entities = dtos };
        }
    }
}