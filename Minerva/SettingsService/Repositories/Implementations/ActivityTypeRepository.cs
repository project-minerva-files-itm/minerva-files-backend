using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Implementations;

public class ActivityTypeRepository : GenericRepository<ActivityType>, IActivityTypeRepository
{
    private readonly IDataConext _context;

    public ActivityTypeRepository(IDataConext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<ActivityType>> AddAsync(ActivityTypeDTO ActivityTypeDTO)
    {
        ActivityType activityType = new ActivityType
        {
            Name = ActivityTypeDTO.Name,
            Description = ActivityTypeDTO.Description,
            LastUser = ActivityTypeDTO.LastUser,
        };
        return await AddAsync(activityType);
    }
}