using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.UnitsOfWork.Interfaces;

public interface IRequestTypeUnitOfWork
{
    Task<ActionResponse<RequestType>> AddAsync(RequestTypeDTO requestTypeDTO);
}