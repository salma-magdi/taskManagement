using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagmentApplication.DTO.response
{
    public record GetProjectResponse(
      int Id,
      string Name,
      string Description,
      DateTime CreatedAt
  );
}
