using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.UnitsOfWork.Interfaces;

public interface IActivityStateUnitOfWork
{
    Task<ActionResponse<ActivityState>> AddAsync(ActivityStateDTO ActivityStateDTO);
}