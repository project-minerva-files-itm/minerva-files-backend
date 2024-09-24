using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations;

public class ActivityStateUnitOfWork : GenericUnitOfWork<ActivityState>, IActivityStateUnitOfWork
{
    private readonly IActivityStateRepository _activityStateRepository;

    public ActivityStateUnitOfWork(IGenericRepository<ActivityState> repository, IActivityStateRepository activityStateRepository) : base(repository)
    {
        _activityStateRepository = activityStateRepository;
    }

    public async Task<ActionResponse<ActivityState>> AddAsync(ActivityStateDTO ActivityStateDTO) => await _activityStateRepository.AddAsync(ActivityStateDTO);
}