using Azure;
using Microsoft.EntityFrameworkCore;
using SettingsService.Data;
using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Implementations;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    private readonly IDataConext _context;
    private readonly DataContext _dataContext;

    public EmployeeRepository(IDataConext context, DataContext dataContext) : base(context)
    {
        _context = context;
        _dataContext = dataContext;
    }

    public async Task<ActionResponse<Employee>> AddAsync(EmployeeDTO employeeDTO)
    {
        Employee employee = new Employee
        {
            FirstName = employeeDTO.FirstName,
            LastName = employeeDTO.LastName,
            Email = employeeDTO.Email,
            PhoneNumber = employeeDTO.PhoneNumber,
            HireDate = employeeDTO.HireDate,
        };

        return await AddAsync(employee);
    }

    public override async Task<ActionResponse<Employee>> GetAsync(int id)
    {
        var employees = await _dataContext.Employees
           .Include(x => x.Department)
           .FirstOrDefaultAsync(x => x.Id == id);

        if (employees == null)
        {
            return new ActionResponse<Employee>.ActionResponseBuilder()
            .SetSuccess(false)
            .SetMessage("ERROO1")
            .Build();
        }

        return new ActionResponse<Employee>.ActionResponseBuilder()
           .SetSuccess(true)
           .SetResult(employees)
           .SetMessage("Operation completed successfully.")
           .Build();
    }

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync()
    {
        var employees = await _dataContext.Employees
            .Include(x => x.Department)
            .ToListAsync();
        return new ActionResponse<IEnumerable<Employee>>.ActionResponseBuilder()
            .SetSuccess(true)
            .SetResult(employees)
            .SetMessage("Operation completed successfully.")
            .Build();
    }

    public async Task<IEnumerable<Employee>> GetComboAsync()
    {
        return await _dataContext.Employees
            .OrderBy(x => x.LastName)
            .ToListAsync();
    }
}