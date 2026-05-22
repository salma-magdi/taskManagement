using taskManagement.entity;
using TaslManagementinfratstructure.respository;

namespace TaslManagementinfratstructure.respository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;

        public IProjectRepository Projects { get; }
        public ITaskRepository Tasks { get; }

        public UnitOfWork(AppDBContext context)
        {
            _context = context;
            Projects = new ProjectRepository(_context);
            Tasks = new TaskRepository(_context);
        }


        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}