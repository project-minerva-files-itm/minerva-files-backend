using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<ActionResponse<Employee>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync();

    Task<IEnumerable<Employee>> GetComboAsync();

    Task<ActionResponse<Employee>> AddAsync(EmployeeDTO employeeDTO);
}