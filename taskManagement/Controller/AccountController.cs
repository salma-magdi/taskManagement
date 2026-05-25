using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentApplication.command;
using TaskManagmentApplication.command.authenticationCommand;
using TaskManagmentApplication.DTO.request;

namespace taskManagementApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator mediator;

        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO registeredUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new RegisterCommand(registeredUser);

            var data = await mediator.Send(command);

            return Ok(data);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO user)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var command = new LoginCommand(user);
            var data = await mediator.Send(command);
            return Ok(data);


        }
    }
}