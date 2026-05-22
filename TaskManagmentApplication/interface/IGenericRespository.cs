using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taskManagement.entity
{
    public interface IGenericRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        public Task<T> GetByIdAsync(int id);



    }
}
