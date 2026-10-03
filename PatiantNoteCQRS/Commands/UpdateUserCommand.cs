using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PatiantNoteCQRS.Commands
{
    public class UpdateUserCommand:IRequest<object>
    {
        public int UserId { get; set; }

        public string FullName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; }

        public string PasswordHash { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

        public bool? IsActive { get; set; }
    }
}
