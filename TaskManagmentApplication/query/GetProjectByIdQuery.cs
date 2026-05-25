using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.query
{
   public record GetProjectByIdQuery :IRequest<generalApiResponse<GetProjectResponse>>
    {
       internal readonly int _projectId;

        public GetProjectByIdQuery(int projectId)
        {
            _projectId = projectId;
        }
    }
}
