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
  public class CreateTaskHandler:IRequestHandler<CreateTaskCommand,GetTaskResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public CreateTaskHandler(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task<GetTaskResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            //mapping 
           var entity=  _mapper.Map<TaskItem>(request.request);
            // create the task
             await _unit.Tasks.CreateAsync(entity);
            await _unit.SaveAsync();
            // mapping 
            var createdEntity= _mapper.Map<GetTaskResponse>(entity);
           
            return createdEntity;
        }
    }
}
