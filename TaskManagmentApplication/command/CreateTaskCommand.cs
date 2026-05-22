using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.DTO.response;

namespace TaskManagmentApplication.command
{
    public class CreateTaskCommand:IRequest<GetTaskResponse>
    {
        public CreateTaskCommand(CreateTaskRequest request)
        {
            this.request = request;
        }

        public CreateTaskRequest request { get;}

    }
}
