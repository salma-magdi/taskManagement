using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.query;

namespace TaskManagmentApplication.Handler
{
    public class GetTasksInProjectHandler : IRequestHandler<GetTaskByProjectQuery, IEnumerable<GetTaskResponse>>
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public GetTasksInProjectHandler(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public async  Task<IEnumerable<GetTaskResponse>> Handle(GetTaskByProjectQuery request, CancellationToken cancellationToken)
        {
            // get all task in the project 
            var tasks = await unit.Tasks.GetTasksByProjectIdAsync(request.ProjectId);

            var result = mapper.Map<IEnumerable<GetTaskResponse>>(tasks);

            return result;

        }
    }
}