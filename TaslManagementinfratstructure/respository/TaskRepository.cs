using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;
using TaslManagementinfrastructure.service;

namespace TaslManagementinfratstructure.respository
{
    public class TaskRepository : GenericRespository<TaskItem>, ITaskRepository
    {
        public TaskRepository(AppDBContext _context,IRedisCache _cache) : base(_context,_cache)
        {
        }

        public async Task<IEnumerable<TaskItem>> GetTasksByProjectIdAsync(int projectId)
        {
            // get task by project 
            return await db.Include(t => t.Project).Where(t => t.ProjectId == projectId).ToListAsync();
                
        }
    }
}
