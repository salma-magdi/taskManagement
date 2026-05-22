using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using taskManagement.entity;
using TaslManagementinfrastructure;

namespace TaslManagementinfratstructure
{
    public class AppDBContext : IdentityDbContext<ApplicationUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> users { get; set; }

        public DbSet<Project> projects { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}