using SharedLibrary.DTOs;
using SharedLibrary.Responses;


namespace SharedLibrary.Repositories.Interfaces
{
    public interface IGenericRepository<T>
    {
        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAsync();

        Task<ActionResponse<T>> AddAsync(T entity);

        // Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination);

        /* Task<ActionResponse<int>> GetTotalRecordsAsync();

         Task<ActionResponse<T>> AddAsync(T entity);

         Task<ActionResponse<T>> DeleteAsync(int id);

         Task<ActionResponse<T>> UpdateAsync(T entity);*/
    }
}
