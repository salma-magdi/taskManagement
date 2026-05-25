using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using taskManagement.entity;
using TaskManagmentApplication.command;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.query;

namespace taskManagementApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class projectController : ControllerBase
    {
        private readonly IMediator mediator;

        public projectController(IMediator mediator, IUnitOfWork unit) : base()
        {
            this.mediator = mediator;
        }

        [HttpGet("gellAllProject")]
        public async Task<IActionResult> getAllproject()
        {
            var query = new GetAllProjectQuery();
            if (query == null)
            {
                return BadRequest("query is null");
            }
            var result = await mediator.Send(query);

            return Ok(result);


        }
        [HttpGet("getProjectById")]
        public async Task<IActionResult> GetProjectById(int id)
        {

            var query = new GetProjectByIdQuery(id);
            if (query == null)
            {
                return BadRequest("notfound");
            }
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpPost("createProject")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            var command = new CreateprojectCommand(request);

            var data = await mediator.Send(command);

            return CreatedAtAction(
                nameof(GetProjectById),
                
                data
            );
        }
        [HttpPut("updateProject")]
        public async Task<IActionResult> updateProject(int id,[FromBody] UpdateProjectRequest request)
        {

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            var command = new UpdateProjectCommand(id,request);
            var data = await mediator.Send(command);
            return Ok(data);


        }

        [HttpDelete]
        public  async Task<IActionResult> deleteProject (int id)
        {

            var command=new DeleteProjectCommand(id);
            var data=await mediator.Send(command);
            //if (data == null)
            //{
            //    return NotFound();
            //}
            return Ok("deleted successfull");
        }

    }
}
