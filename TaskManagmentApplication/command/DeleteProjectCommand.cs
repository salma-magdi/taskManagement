using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.command
{
    public class DeleteProjectCommand:IRequest<bool>
    {
        public DeleteProjectCommand(int id)
        {
            this.id = id;
        }

        public int id {  get; set; }

    }
}
