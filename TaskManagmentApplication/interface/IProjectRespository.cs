using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManagement.entity { 
 
 public interface IProjectRepository : IGenericRepository<Project>
        {
            Task<IEnumerable<Project>> GetAllProjectsAsync();
            Task<Project> GetProjectByIdAsync(int id);
        }
    }

