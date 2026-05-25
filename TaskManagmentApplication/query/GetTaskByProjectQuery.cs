using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.query
{
  public record GetTaskByProjectQuery :IRequest<generalApiResponse<IEnumerable<GetTaskResponse>>>
    {
        public GetTaskByProjectQuery(int projectId)
        {
            ProjectId = projectId;
        }

        public int ProjectId {  get; set; }
    }
}
