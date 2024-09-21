using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations
{
    public class CompanyUnitOfWork : GenericUnitOfWork<Company>, ICompanyUnitOfWork
    {

        private readonly ICompanyRepository _companyRepository;


        public CompanyUnitOfWork(IGenericRepository<Company> repository, ICompanyRepository companyRepository) : base(repository)
        {
            _companyRepository=companyRepository;
        }


        public async Task<ActionResponse<Company>> AddAsync(CompanyDTO groupDTO)
        {
           return await _companyRepository.AddAsync(groupDTO);
        }
    }
}
