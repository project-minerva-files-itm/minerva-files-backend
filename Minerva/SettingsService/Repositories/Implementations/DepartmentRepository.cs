using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Implementations;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    private readonly IDataConext _context;

    public DepartmentRepository(IDataConext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<Department>> AddAsync(DepartmentDTO departmentDTO)
    {
        Department department = new Department
        {
            Name = departmentDTO.Name,
            Description = departmentDTO.Description,
            Location = departmentDTO.Location,
        };
        return await AddAsync(department);
    }
}