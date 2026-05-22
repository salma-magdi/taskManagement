using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskManagement.entity;
using TaskManagmentApplication.command;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.query;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace taskManagementApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {

        private readonly IMediator mediator;

        public TaskController(IMediator mediator, IUnitOfWork unit) : base()
        {
            this.mediator = mediator;
        }

        [HttpGet("GetTaskWithinProject")]
        public async Task<IActionResult> getTaskWithinProject( int ProjectId)
        {
            var query = new GetTaskByProjectQuery(ProjectId);
            if (query == null)
            {
                return BadRequest("notFound");
            }

            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("createTask")]
        public async Task<IActionResult> createTask([FromBody]CreateTaskRequest request )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid");

            }
       
                
            var command = new CreateTaskCommand(request);
            // mapping 

            var data = await mediator.Send(command);
            return CreatedAtAction(
            nameof(getTaskWithinProject),
            new { name = data.Name },
            data);

        }

       
        [HttpPut("updatestatus")]
        public async Task<IActionResult> UpdateTaskStatus(int taskId,[FromBody] UpdateTaskRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Data not valid");
            }

            var command = new UpdateTaskStatusCommand(taskId, request.Status);

            var data = await mediator.Send(command);

            if (!data)
            {
                return NotFound("Task not found");
            }

            return Ok("Task status updated successfully");
        }
        
        
        [HttpDelete("deleteTask")]
        public async Task<IActionResult> DeleteTask(int id )
        {
            var command =new DeleteTaskCommand(id);
            var data = await mediator.Send(command);
            return Ok(data);
        }
    }
}
