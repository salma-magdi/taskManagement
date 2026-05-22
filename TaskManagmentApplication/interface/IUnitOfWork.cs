using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManagement.entity
{
    public interface IUnitOfWork
    {
        IProjectRepository Projects { get; }
        ITaskRepository Tasks { get; }

        Task<int> SaveAsync();
    }

}
