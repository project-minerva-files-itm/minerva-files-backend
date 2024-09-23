using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;


namespace SettingsService.Repositories.Implementations
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly IDataConext _context;
   
        public CompanyRepository(IDataConext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionResponse<Company>> AddAsync(CompanyDTO groupDTO)
        {
            Company company = new Company
            {
                Name = groupDTO.Name,
                Document = groupDTO.Document,
                Address = groupDTO.Address,
                Phone = groupDTO.Phone,
                Email = groupDTO.Email,
                NumberEmployees = groupDTO.NumberEmployees,
            };

              return await AddAsync(company);
       
        }
    }
}
