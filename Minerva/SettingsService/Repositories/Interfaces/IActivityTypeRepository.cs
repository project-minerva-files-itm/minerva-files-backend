using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces;

public interface IActivityTypeRepository
{
    Task<ActionResponse<ActivityType>> AddAsync(ActivityTypeDTO ActivityTypeDTO);
}