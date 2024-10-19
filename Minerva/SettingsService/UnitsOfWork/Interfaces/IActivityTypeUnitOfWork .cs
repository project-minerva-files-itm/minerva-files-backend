using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.UnitsOfWork.Interfaces;

public interface IActivityTypeUnitOfWork
{
    Task<ActionResponse<ActivityType>> AddAsync(ActivityTypeDTO activityTypeDTO);
}