using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SettingsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActivityStatesController : GenericController<ActivityState>
{
    private readonly IActivityStateUnitOfWork _activityStateUnitOfWork;

    public ActivityStatesController(IGenericUnitOfWork<ActivityState> unitOfWork, IActivityStateUnitOfWork activityStateUnitOfWork) : base(unitOfWork)
    {
        _activityStateUnitOfWork = activityStateUnitOfWork;
    }
}