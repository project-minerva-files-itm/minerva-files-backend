using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces;

public interface IActivityStateRepository
{
    Task<ActionResponse<ActivityState>> AddAsync(ActivityStateDTO ActivityStateDTO);
}