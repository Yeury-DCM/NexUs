
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NexUs.Core.Application.Interfaces.Repositories;
using NexUs.Core.Domain.Result;
using NexUs.Infrastructure.Persistence.Contexts;
using System.Linq;

namespace NexUs.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;
        private ILogger _logger;

        public GenericRepository(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _entities = _context.Set<T>();  
        }

        public async Task<OperationResult<T>> AddAsync(T entity)
        {
            OperationResult<T> result = new();

            try
            {
                await _entities.AddAsync(entity);
                await _context.SaveChangesAsync();
                result.Data = entity;
                result.Message = "The entity was added correctly";
            }
            catch (Exception ex)
            {
                result.Message = "An error occurred while adding the entity";
                result.IsSucess = false;
                _logger.LogError(result.Message, ex);
            }
          
            return result;
        }

        public async Task<OperationResult<T>> DeleteAsync(int id)
        {
            OperationResult<T> result = new();

            try
            {
                OperationResult<T> getByIdResult = await GetByIdAsync(id);

                _entities.Remove(getByIdResult.Data!);
                await _context.SaveChangesAsync();


                result.Message = "The entity was deleted sucessfully";
            }
            catch (Exception ex)
            {
                result.Message = "An error occurred while deleting the entity";
                result.IsSucess = false;
                _logger.LogError(result.Message, ex);
            }

            return result;
        }

        public async Task<OperationResult<IQueryable<T>>> GetAllAsync()
        {
            OperationResult<IQueryable<T>> result = new();

            try
            {
                result.Data = _entities.AsQueryable();
                await _context.SaveChangesAsync();

                result.Message = "The entities have been retrieved correctly";

            }
            catch (Exception ex)
            {
                result.Message = "An error occurred while retrieving the entities";
                result.IsSucess = false;
                _logger.LogError(result.Message, ex);
            }

            return result;
        }

        public async Task<OperationResult<T>> GetByIdAsync(int Id)
        {
            OperationResult<T> result = new();

            try
            {

                result.Data = await _entities.FindAsync(Id);
                await _context.SaveChangesAsync();

                result.Message = "The entity was retrieved sucessfully";
            }
            catch (Exception ex)
            {
                result.Message = "An error occurred while retrieving the entity";
                result.IsSucess = false;
                _logger.LogError(result.Message, ex);
            }

            return result;
        }

        public async Task<OperationResult<T>> UpdateAsync(T entity)
        {
            OperationResult<T> result = new();

            try
            {            
                _entities.Update(entity);
                await _context.SaveChangesAsync();
                result.Data = entity; 
                result.Message = "The entity was updated sucessfully";
            }
            catch (Exception ex)
            {
                result.Message = "An error occurred while updating the entity";
                result.IsSucess = false;
                _logger.LogError(result.Message, ex);
            }

            return result;
        }
    }
}
