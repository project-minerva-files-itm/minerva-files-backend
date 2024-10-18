using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.UnitsOfWork.Interfaces;

public interface IDepartmentUnitOfWork
{
    Task<ActionResponse<Department>> AddAsync(DepartmentDTO departmentDTO);
}