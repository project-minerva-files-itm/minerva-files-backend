using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Implementations;

public class ActivityStateRepository : GenericRepository<ActivityState>, IActivityStateRepository
{
    private readonly IDataConext _context;

    public ActivityStateRepository(IDataConext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<ActivityState>> AddAsync(ActivityStateDTO groupDTO)
    {
        ActivityState activityState = new ActivityState
        {
            Name = groupDTO.Name,
            Description = groupDTO.Description,
        };
        return await AddAsync(activityState);
    }
}