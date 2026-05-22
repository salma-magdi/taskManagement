using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.command
{
    public class DeleteTaskCommand:IRequest<bool>
    {
        public DeleteTaskCommand(int taskId)
        {
            TaskId = taskId;
        }

        public int TaskId {  get; set; }
    }
}
