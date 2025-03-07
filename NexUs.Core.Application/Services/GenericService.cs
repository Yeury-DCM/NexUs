using AutoMapper;
using NexUs.Core.Application.Interfaces.Repositories;
using NexUs.Core.Application.Interfaces.Services;
using NexUs.Core.Domain.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexUs.Core.Application.Services
{
    public class GenericService<ViewModel, SaveViewModel, Entity> : IGenericService<ViewModel, SaveViewModel, Entity>
        where ViewModel : class, IHasId
        where Entity : class
        where SaveViewModel : class, IHasId
    {
        private readonly IGenericRepository<Entity> _repository;
        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<SaveViewModel> Add(SaveViewModel saveViewModel)
        {
            Entity entity = _mapper.Map<Entity>(saveViewModel);
            OperationResult<Entity> result = await _repository.AddAsync(entity);
            return _mapper.Map<SaveViewModel>(result.Data);
        }

        public virtual async Task<bool> Delete(int id)
        {
            OperationResult<Entity> result = await _repository.DeleteAsync(id);
            return result.IsSucess;
        }

        public virtual async Task<List<ViewModel>> GetAllViewModel()
        {
            OperationResult<IQueryable<Entity>> result = await _repository.GetAllAsync();
            List<Entity> entities = result.Data!.ToList()!;

            return _mapper.Map<List<ViewModel>>(entities);
        }

        public async Task<ViewModel?> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<ViewModel>(result.Data!);
        }

        public async Task<SaveViewModel> GetByIdSaveViewModel(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<SaveViewModel>(result.Data!);
        }

        public async Task<bool> Update(SaveViewModel viewModel)
        {
            var getByIdResult = await _repository.GetByIdAsync(viewModel.Id);
            Entity entity = getByIdResult.Data!;
            entity = _mapper.Map(viewModel, entity);
            var updateResult = await _repository.UpdateAsync(entity);
            return updateResult.IsSucess;

          
        }
    }
}
