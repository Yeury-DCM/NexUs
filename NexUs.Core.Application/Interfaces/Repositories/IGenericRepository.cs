using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository <T> where T : class
    {

        Task<IQueryable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int Id);
        Task<T> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);

    }
}
