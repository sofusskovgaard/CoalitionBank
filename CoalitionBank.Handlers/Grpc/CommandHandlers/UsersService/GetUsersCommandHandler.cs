using System.Collections;
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
    public class GetUsersCommandHandler : GrpcCommandHandler<GetUsersCommand, GetUsersCommandResult>
    {
        private readonly IDataContext _dataContext;

        private readonly IMapper _mapper;

        public GetUsersCommandHandler(IDataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public override async Task<GetUsersCommandResult> Invoke(GetUsersCommand command)
        {
            var entities = await _dataContext.Get<UserEntity>("global", command.Page, command.PageSize);
            return new GetUsersCommandResult() { Users = _mapper.Map<IEnumerable<UserDto>>(entities) };
        }
    }
}