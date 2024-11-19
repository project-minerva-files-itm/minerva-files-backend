using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Interfaces;

public interface IDepartmentRepository
{
    Task<ActionResponse<Department>> AddAsync(DepartmentDTO departmentDTO);
}