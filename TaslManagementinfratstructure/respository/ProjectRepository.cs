using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;

namespace TaslManagementinfratstructure.respository
{
    public class ProjectRepository : GenericRespository<Project>, IProjectRepository
    {
        private readonly AppDBContext context;
       
       

        public ProjectRepository(AppDBContext _context) : base(_context)
        {
            this.context = _context;
            
        }


        // get allproject 
        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
           //get all projects
            return await db.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            // get project by id 
            return  await db.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
