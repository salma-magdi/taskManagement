using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.query;

namespace TaskManagmentApplication.Handler
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectQuery,IEnumerable<GetProjectResponse>>
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;
        public GetAllProjectsHandler( IMapper _mapper,IUnitOfWork _unit)
        {
            this.mapper = _mapper;
            this.unit = _unit;
        }

        public async Task<IEnumerable<GetProjectResponse>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
        {
            // get all project 
           var entities = await unit.Projects.GetAllProjectsAsync();
            //mapping db to response 
            return  mapper.Map<IEnumerable<GetProjectResponse>>(entities);
                }
    }
}
