using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.command.commandVersioning
{
    public class createProjectVersionCommand : IRequest<string>
    {
        public createProjectVersionCommand(createProjectVersioning request)
        {
            this.request = request;
        }

        public createProjectVersioning request { get; set; }
       

    }
}
