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
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, GetProjectResponse>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public GetProjectByIdHandler(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public async Task<GetProjectResponse> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            // getby id 
            var entity= await unit.Projects.GetProjectByIdAsync(request._projectId);
            // mapping to db to response 
           return   mapper.Map<GetProjectResponse>(entity);
            
        }
    }
}
