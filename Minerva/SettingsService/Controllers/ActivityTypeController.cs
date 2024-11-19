using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SettingsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityTypeController : GenericController<ActivityType>
{
    private readonly IActivityTypeUnitOfWork _activityTypeUnitOfWork;

    public ActivityTypeController(IGenericUnitOfWork<ActivityType> unitOfWork, IActivityTypeUnitOfWork activityTypeUnitOfWork) : base(unitOfWork)
    {
        _activityTypeUnitOfWork = activityTypeUnitOfWork;
    }
}