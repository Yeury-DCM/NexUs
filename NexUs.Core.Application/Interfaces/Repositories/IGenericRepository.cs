using NexUs.Core.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository <T> where T : class
    {

        Task<OperationResult<IQueryable<T>>> GetAllAsync();
        Task<OperationResult<T>> GetByIdAsync(int Id);
        Task<OperationResult<T>> AddAsync(T entity);
        Task<OperationResult<T>> UpdateAsync(T entity);
        Task<OperationResult<T>> DeleteAsync(int id);

    }
}
