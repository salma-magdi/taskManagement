using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagmentApplication.DTO.request;

namespace TaskManagmentApplication.validator
{
    public class createTaskValidator : AbstractValidator<CreateTaskRequest>
    {
        public createTaskValidator()
        {
            //name validation
            RuleFor(x => x.Name).NotEmpty().WithMessage("Task name is required")
            .MinimumLength(3).WithMessage("Task name must be at least 3 characters");
            //description validation
            RuleFor
                (x => x.Description).NotEmpty().WithMessage("Task description is required");
            //duedate validation
            RuleFor(x => x.DueDate).NotEmpty().WithMessage("Due date is required")
                .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future");
            //priority validation
            RuleFor(x => x.Priority).IsInEnum().WithMessage("Invalid priority value");
            //projectid validation
            RuleFor(x => x.ProjectId).NotEmpty().WithMessage("ProjectId is required");

        }
    }
}
