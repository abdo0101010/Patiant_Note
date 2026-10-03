using MediatR;
using Microsoft.AspNetCore.Mvc;
using PatiantNoteCQRS._َqueries;
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
        [HttpPost(Routes.Route.UserRoutes.create)]

        public async Task<User> AddUser([FromBody] AddUserCommand command)
        {
            
            return await _Mediator.Send(command);
           
        }

        [HttpGet(Routes.Route.UserRoutes.baseurl)]
        public async Task<List<User>> ReadUsers()
        {
            var query = new ReadUsersQuery();
            return await _Mediator.Send(query);

        }
        [HttpPut(Routes.Route.UserRoutes.update)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand UpdatedUser)
        {
            await _Mediator.Send(UpdatedUser);
            return Ok();
        } 
    }
}
