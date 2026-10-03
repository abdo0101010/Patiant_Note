using MediatR;
using PatiantNoteCQRS._َqueries;
using PatiantNoteCQRS.Interfaces;
using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS.Handler.QueriesHandler
{
    public class ReadUsersQueryHandler(IUser userService) : IRequestHandler<ReadUsersQuery, List<User>>
    {
        private readonly IUser _userService = userService;
        public async Task<List<User>> Handle(ReadUsersQuery request, CancellationToken cancellationToken)
        {
            var oData =await _userService.GetAllUsers();
            return oData;

        }
    }
}
