using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.DTO.request
{
    public record CreateProjectRequest(
       
    string Name,
    string Description,
    int UserId
);
}
