using SettingsService.Repositories.Interfaces;
using SettingsService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace SettingsService.UnitsOfWork.Implementations;

public class RequestTypeUnitOfWork : GenericUnitOfWork<RequestType>, IRequestTypeUnitOfWork
{
    private readonly IRequestTypeRepository _requestTypeRepository;

    public RequestTypeUnitOfWork(IGenericRepository<RequestType> repository, IRequestTypeRepository requestTypeRepository) : base(repository)
    {
        _requestTypeRepository = requestTypeRepository;
    }

    public async Task<ActionResponse<RequestType>> AddAsync(RequestTypeDTO requestTypeDTO) => await _requestTypeRepository.AddAsync(requestTypeDTO);
}