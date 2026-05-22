using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using taskManagement.entity;

namespace TaslManagementinfratstructure.respository
{
    public class GenericRespository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDBContext context;
      internal readonly DbSet<T> db;
        
        public GenericRespository( AppDBContext _context)
        {
            this.context = _context;
            this.db = context.Set<T>();
        }


        
        public async Task<T> CreateAsync(T entity)
        {
            // create 
           await  db.AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            // find id 
            var entity = await db.FindAsync(id);
            if (entity != null)
            {
                // delete 
                db.Remove(entity);
            }

           
            
        }
        // update 
        public async Task UpdateAsync(T entity)
        {
            // update 
            // get the entity want to update 

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

             db.Update(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.FindAsync(id);
        }
    }
}
