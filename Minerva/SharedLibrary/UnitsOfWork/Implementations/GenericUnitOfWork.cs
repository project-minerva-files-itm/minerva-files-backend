﻿using SharedLibrary.DTOs;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SharedLibrary.UnitsOfWork.Implementations
{
    public class GenericUnitOfWork<T> : IGenericUnitOfWork<T> where T : class
    {
        private readonly IGenericRepository<T> _repository;

        public GenericUnitOfWork(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T model) => await _repository.AddAsync(model);

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id) => await _repository.DeleteAsync(id);

        public virtual async  Task<ActionResponse<IEnumerable<T>>> GetAllAsync(PaginationDTO pagination) => await _repository.GetAsync(pagination);

        public virtual async Task<ActionResponse<T>> GetAsync(int id) => await _repository.GetAsync(id);

 
        public virtual async Task<ActionResponse<T>> UpdateAsync(T model) => await _repository.UpdateAsync(model);


    }
}
