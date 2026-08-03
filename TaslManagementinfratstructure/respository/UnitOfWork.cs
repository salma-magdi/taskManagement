using taskManagement.entity;
using TaslManagementinfrastructure.service;
using TaslManagementinfratstructure.respository;

namespace TaslManagementinfratstructure.respository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        private readonly IRedisCache _cache;

        public IProjectRepository Projects { get; }
        public ITaskRepository Tasks { get; }

        public UnitOfWork(AppDBContext context, IRedisCache cache)
        {
            _context = context;
            _cache = cache;

            Projects = new ProjectRepository(_context, _cache);
            Tasks = new TaskRepository(_context, _cache);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
}
      
    }
