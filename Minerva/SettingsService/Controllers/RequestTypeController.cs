using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SettingsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestTypeController : GenericController<RequestType>
{
    private readonly IRequestTypeUnitOfWork _requestTypeUnitOfWork;

    public RequestTypeController(IGenericUnitOfWork<RequestType> unitOfWork, IRequestTypeUnitOfWork requestTypeUnitOfWork) : base(unitOfWork)
    {
        _requestTypeUnitOfWork = requestTypeUnitOfWork;
    }
}