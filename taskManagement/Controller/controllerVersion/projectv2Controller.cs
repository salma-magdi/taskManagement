using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagmentApplication.command.commandVersioning;
using TaskManagmentApplication.DTO.request;

namespace taskManagementApi.Controller.controllerVersion
{
    [Route("api/v{version:apiVersion}/projects")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createProject")]
        public async Task<IActionResult> CreateProject([FromBody] createProjectVersioning request)
        {
            var command = new createProjectVersionCommand(request);
           

            var data = await _mediator.Send(command);

            return Ok(data);
        }
    }
}