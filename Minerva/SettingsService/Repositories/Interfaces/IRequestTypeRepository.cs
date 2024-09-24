using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces;

public interface IRequestTypeRepository
{
    Task<ActionResponse<RequestType>> AddAsync(RequestTypeDTO RequestTypeDTO);
}