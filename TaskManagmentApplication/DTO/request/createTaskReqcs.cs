using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity.enums;

namespace TaskManagmentApplication.DTO.request
{
  public record CreateTaskRequest(
    string Name,
    string Description,
    DateTime DueDate,
    PriorityEnum Priority,
    int ProjectId
);
}
