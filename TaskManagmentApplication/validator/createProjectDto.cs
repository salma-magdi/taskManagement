using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.validator
{
public class createProjectDto :AbstractValidator<CreateProjectRequest>
    {

        public createProjectDto() {

            //name validation
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Project name is required")
            .MinimumLength(3).WithMessage("Project name must be at least 3 characters");

            //description validation
            RuleFor
                (x => x.Description).NotEmpty().WithMessage("Project description is required");


            //userid validation
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId is required");




        }
    }
}
