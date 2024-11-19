using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations;

public class ActivityTypeUnitOfWork : GenericUnitOfWork<ActivityType>, IActivityTypeUnitOfWork
{
    private readonly IActivityTypeRepository _activityTypeRepository;

    public ActivityTypeUnitOfWork(IGenericRepository<ActivityType> repository, IActivityTypeRepository activityTypeRepository) : base(repository)
    {
        _activityTypeRepository = activityTypeRepository;
    }

    public async Task<ActionResponse<ActivityType>> AddAsync(ActivityTypeDTO activityTypeDTO) => await _activityTypeRepository.AddAsync(activityTypeDTO);
}