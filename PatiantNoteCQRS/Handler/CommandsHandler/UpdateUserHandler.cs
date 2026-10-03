using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PatiantNoteCQRS.Commands;
using PatiantNoteCQRS.Interfaces;
using PatiantNoteCQRS.Models;
using System.Net;

namespace PatiantNoteCQRS.Handler.CommandsHandler
{
    public class UpdateUserHandler(IUser service) : IRequestHandler<UpdateUserCommand, object>
    {
        private readonly IUser _service = service;
        

        async Task<dynamic> IRequestHandler<UpdateUserCommand, object>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var User = new User()
            {
                FullName = request.FullName,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PasswordHash = request.PasswordHash

            };
            await _service.UpdateUser(request.UserId, User);
            return ((int)HttpStatusCode.Accepted);
        }
    }
}
