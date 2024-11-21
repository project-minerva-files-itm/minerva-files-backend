using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations;

public class EmployeeUnitOfWork : GenericUnitOfWork<Employee>, IEmployeeUnitOfWork
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeeUnitOfWork(IGenericRepository<Employee> repository, IEmployeeRepository employeeRepository) : base(repository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<ActionResponse<Employee>> AddAsync(EmployeeDTO employeeDTO) => await _employeeRepository.AddAsync(employeeDTO);

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync() => await
        _employeeRepository.GetAsync();

    public override async Task<ActionResponse<Employee>> GetAsync(int id) => await _employeeRepository.GetAsync(id);

    public async Task<IEnumerable<Employee>> GetComboAsync() => await _employeeRepository.GetComboAsync();
}