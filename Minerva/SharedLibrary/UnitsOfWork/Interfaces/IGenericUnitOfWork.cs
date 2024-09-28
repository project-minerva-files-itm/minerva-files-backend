using SharedLibrary.DTOs;
using SharedLibrary.Responses;

namespace SharedLibrary.UnitsOfWork.Interfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
      

        Task<ActionResponse<T>> AddAsync(T model);

        Task<ActionResponse<T>> GetAsync(int id);

        Task<ActionResponse<IEnumerable<T>>> GetAllAsync(PaginationDTO pagination);

        Task<ActionResponse<T>> UpdateAsync(T model);

        Task<ActionResponse<T>> DeleteAsync(int id);


    }
}
