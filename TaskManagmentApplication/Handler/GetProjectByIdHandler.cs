using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;
using TaskManagmentApplication.query;

namespace TaskManagmentApplication.Handler
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, generalApiResponse<GetProjectResponse>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public GetProjectByIdHandler(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public async Task<generalApiResponse<GetProjectResponse>> Handle(
     GetProjectByIdQuery request,
     CancellationToken cancellationToken)
        {
            // get entity
            var entity = await unit.Projects
                .GetProjectByIdAsync(request._projectId);

            // null check
            if (entity == null)
            {
                throw new Exception("Project not found");
            }

            // mapping
            var response = mapper.Map<GetProjectResponse>(entity);

            // return response
            return generalApiResponse<GetProjectResponse>
                .SuccessResult(response, "Project retrieved successfully");
        }
    }
}
