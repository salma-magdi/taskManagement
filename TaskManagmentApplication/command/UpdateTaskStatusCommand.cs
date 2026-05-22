using MediatR;
using taskManagement.entity.enums;

namespace TaskManagmentApplication.command
{
    public class UpdateTaskStatusCommand : IRequest<bool>
    {
        public int TaskId { get; set; }
        public taskStatus Status { get; set; }

        public UpdateTaskStatusCommand(int taskId, taskStatus status)
        {
            TaskId = taskId;
            Status = status;
        }
    }
}