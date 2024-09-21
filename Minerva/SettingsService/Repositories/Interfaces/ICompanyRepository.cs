using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces
{
    public interface ICompanyRepository
    {
        Task<ActionResponse<Company>> AddAsync(CompanyDTO groupDTO);
    }
}
