using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.command;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.DTO.response;

namespace TaskManagmentApplication.Handler
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, GetProjectResponse>
    {

        private readonly IMapper mapper;
        private readonly IUnitOfWork unit;

        public UpdateProjectHandler(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        public async Task<GetProjectResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            // get project
            var entity = await unit.Projects.GetProjectByIdAsync(request.Id);

            if (entity == null)
                throw new Exception("Project not found");

            // update fields
            entity.Name = request.Request.Name;
            entity.Description = request.Request.Description;

            // save changes
            await unit.Projects.UpdateAsync(entity);
            await unit.SaveAsync();

            // map entity (NOT update result)
            var mapped = mapper.Map<GetProjectResponse>(entity);

            return mapped;
        }
    }
}
