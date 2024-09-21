using Microsoft.AspNetCore.Mvc;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SettingsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : GenericController<Company>
    {

        private readonly ICompanyUnitOfWork _companyUnitOfWork;

        public CompanyController(IGenericUnitOfWork<Company> unitOfWork, ICompanyUnitOfWork companyUnitOfWork) : base(unitOfWork)
        {
            _companyUnitOfWork = companyUnitOfWork;
        }


    }
}
