using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SettingsService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentController : GenericController<Department>
{
    private readonly IDepartmentUnitOfWork _departmentUnitOfWork;

    public DepartmentController(IGenericUnitOfWork<Department> unitOfWork, IDepartmentUnitOfWork departmentUnitOfWork) : base(unitOfWork)
    {
        _departmentUnitOfWork = departmentUnitOfWork;
    }
}