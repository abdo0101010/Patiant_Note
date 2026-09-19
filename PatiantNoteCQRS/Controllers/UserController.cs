using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatiantNoteCQRS.Commands;
using PatiantNoteCQRS.Models;

namespace PatiantNoteCQRS.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _Mediator;
        public UserController(IMediator mediator)
        {
            _Mediator = mediator;
        }
        [HttpPost("AddUser")]

        public async Task<User> AddUser([FromBody] AddUserCommand command)
        {
            
            return await _Mediator.Send(command);
           
        }
    }
}
