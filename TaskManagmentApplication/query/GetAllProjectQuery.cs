using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.response;

namespace TaskManagmentApplication.query
{
  public record GetAllProjectQuery:IRequest<IEnumerable<GetProjectResponse>>
    {
        // get all projects
    }
}
