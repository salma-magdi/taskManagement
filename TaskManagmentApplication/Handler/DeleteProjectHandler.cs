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
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, bool>
    {
       
        private readonly IUnitOfWork unit;

        public DeleteProjectHandler(IMapper mapper, IUnitOfWork unit)
        {
           
            this.unit = unit;
        }

        public async Task<bool> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            // get by id 
           var entity=  await unit.Projects.GetProjectByIdAsync(request.id);
            if (entity == null)
            {
               
                return false;

            }
            //delete 
            await unit.Projects.DeleteAsync(entity.Id);
            await unit.SaveAsync();
            return true;

           

           
        }
    }
}
