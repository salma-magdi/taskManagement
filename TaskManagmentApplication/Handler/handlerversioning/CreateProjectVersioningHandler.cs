using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.command.commandVersioning;
using TaskManagmentApplication.DTO.request;
using TaskManagmentApplication.DTO.response;
using TaskManagmentApplication.generalResponse;

namespace TaskManagmentApplication.Handler.handlerversioning
{
    public class CreateProjectVersioningHandler
     : IRequestHandler<createProjectVersionCommand, string>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public CreateProjectVersioningHandler(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<string> Handle(
            createProjectVersionCommand request,
            CancellationToken cancellationToken)
        {
            // request -> entity
            var entity = _mapper.Map<Project>(request.request);

            // save project
            await _unit.Projects.CreateAsync(entity);
            await _unit.SaveAsync();

            // return version/message only
            return " project created successfully";
        }
    }
}
