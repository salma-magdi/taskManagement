using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.command
{
    public record CreateprojectCommand:IRequest<generalApiResponse<GetProjectResponse>>
    {

        // create a project 
        public  CreateProjectRequest request { get; set; }

        public CreateprojectCommand(CreateProjectRequest _request)
        {
            this.request = _request;
        }
    }
}
