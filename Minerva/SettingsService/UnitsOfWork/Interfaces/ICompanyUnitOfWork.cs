using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;


namespace SettingsService.UnitsOfWork.Interfaces
{
    public interface ICompanyUnitOfWork
    {
        Task<ActionResponse<Company>> AddAsync(CompanyDTO matchDTO);

      //  Task<ActionResponse<Company>> UpdateAsync(CompanyDTO matchDTO);

     //   Task<ActionResponse<Company>> GetAsync(int id);

     //   Task<ActionResponse<IEnumerable<Company>>> GetAsync(PaginationDTO pagination);
    }
}
