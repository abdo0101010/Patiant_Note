using MediatR;
using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS.Commands
{
    public class AddUserCommand:IRequest<User>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

    }
}
