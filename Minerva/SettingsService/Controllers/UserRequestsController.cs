using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SettingsService.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestsController : GenericController<UserRequest> 
    {
        private readonly IRequestTypeUnitOfWork _requestTypeUnitOfWork;

        public UserRequestsController(IGenericUnitOfWork<UserRequest> unitOfWork, IRequestTypeUnitOfWork requestTypeUnitOfWork) : base(unitOfWork)
        {
            _requestTypeUnitOfWork = requestTypeUnitOfWork;
        }
    }
}
