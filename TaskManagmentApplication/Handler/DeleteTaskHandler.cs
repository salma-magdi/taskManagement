using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaskManagmentApplication.command;

namespace TaskManagmentApplication.Handler
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskCommand, bool>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unit;

        public DeleteTaskHandler(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }
        public async Task<bool> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {

            
          
           // delete task 
            await _unit.Tasks.DeleteAsync(request.TaskId);
           await  _unit.SaveAsync();
            return true;
        }
    }
}
