using Challenges.API.UseCases.Users.Commands;
using Challenges.API.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Challenges.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateUser([FromBody]CreateUser command)
        {
            await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<string> GetPassword([FromQuery]GetUserPasswordQuery query)
        {
            return await _mediator.Send(query);
        }
    }
}
