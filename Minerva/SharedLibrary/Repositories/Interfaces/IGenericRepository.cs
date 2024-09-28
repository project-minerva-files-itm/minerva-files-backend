using SharedLibrary.DTOs;
using SharedLibrary.Responses;


namespace SharedLibrary.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        Task<ActionResponse<T>> AddAsync(T entity);

        Task<ActionResponse<T>> UpdateAsync(T entity);

        Task<ActionResponse<T>> DeleteAsync(int id);

  
    }
}
