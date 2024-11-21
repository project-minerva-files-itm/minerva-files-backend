using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.UnitsOfWork.Interfaces;

public interface IEmployeeUnitOfWork
{
    Task<ActionResponse<Employee>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync();

    Task<IEnumerable<Employee>> GetComboAsync();

    Task<ActionResponse<Employee>> AddAsync(EmployeeDTO employeeDTO);
}