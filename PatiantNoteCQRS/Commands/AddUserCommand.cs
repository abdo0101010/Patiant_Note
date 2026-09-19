using MediatR;
using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS.Commands
{
    public class AddUserCommand:IRequest<User>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } 

    }
}
