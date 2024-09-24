using SettingsService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace SettingsService.Repositories.Implementations;

public class RequestTypeRepository : GenericRepository<RequestType>, IRequestTypeRepository
{
    private readonly IDataConext _context;

    public RequestTypeRepository(IDataConext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<RequestType>> AddAsync(RequestTypeDTO RequestTypeDTO)
    {
        RequestType requestType = new RequestType
        {
            Name = RequestTypeDTO.Name,
            Description = RequestTypeDTO.Description,
            LastUser = RequestTypeDTO.LastUser,
        };
        return await AddAsync(requestType);
    }
}