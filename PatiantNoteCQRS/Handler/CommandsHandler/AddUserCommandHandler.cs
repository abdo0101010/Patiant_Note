using MediatR;
using PatiantNoteCQRS.Commands;
using PatiantNoteCQRS.Interfaces;
using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS.Handler.CommandsHandler
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        private readonly IUser _userService;

        public AddUserCommandHandler(IUser userService)
        {
            _userService = userService;
        }

        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = "NotSetYet", 
                CreatedAt = DateTime.Now,
                IsActive = true
            };
            return await _userService.AddUser(user);
        }
    }
}
