using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.validator
{
    public class updateProjectValidator : AbstractValidator<UpdateProjectRequest>
    {
        public updateProjectValidator()
        {

            RuleFor(x => x.Name).NotEmpty().WithMessage("name is required");
            //descrition validation
            RuleFor
                (x => x.Description).NotEmpty().WithMessage("Project description is required");
        }
    }
}
