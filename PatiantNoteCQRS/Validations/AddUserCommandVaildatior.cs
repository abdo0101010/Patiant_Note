using FluentValidation;
using PatiantNoteCQRS.Commands;

namespace PatiantNoteCQRS.Validations
{
    public class AddUserCommandVaildatior:AbstractValidator<AddUserCommand>
    {
        public AddUserCommandVaildatior()
        {
            RuleFor(x=>x.FullName).NotNull().WithMessage("FullName is required");   
            RuleFor(x=>x.Email).EmailAddress().WithMessage("Email is not valid");
            RuleFor(x=>x.PhoneNumber).Matches(@"^\d{10}$").WithMessage("PhoneNumber must be 10 digits");

        }
    }
}
