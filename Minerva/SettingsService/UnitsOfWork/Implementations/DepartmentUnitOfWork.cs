﻿using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations;

public class DepartmentUnitOfWork : GenericUnitOfWork<Department>, IDepartmentUnitOfWork
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentUnitOfWork(IGenericRepository<Department> repository, IDepartmentRepository departmentRepository) : base(repository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<ActionResponse<Department>> AddAsync(DepartmentDTO departmentDTO) => await _departmentRepository.AddAsync(departmentDTO);
}