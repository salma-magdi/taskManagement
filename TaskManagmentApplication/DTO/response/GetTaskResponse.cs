using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity.enums;

namespace TaskManagmentApplication.DTO.response
{
    public record GetTaskResponse(
     int Id,
     string Name,
    string Status,
     DateTime DueDate,
    PriorityEnum Priority
 );
}
