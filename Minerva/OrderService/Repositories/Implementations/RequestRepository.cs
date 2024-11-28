using OrderService.Data;
using OrderService.Repositories.Interfaces;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Implementations;
using SharedLibrary.Responses;

namespace OrderService.Repositories.Implementations;

public class RequestRepository : GenericRepository<Request>, IRequestRepository
{
    private readonly IDataConext _context;
    private readonly DataContext _dataContext;

    public RequestRepository(IDataConext context, DataContext dataContext) : base(context)
    {
        _context = context;
        _dataContext = dataContext;
    }

    public async Task<ActionResponse<Request>> AddAsync(RequestDTO requestDTO)
    {
        Request request = new Request
        {
            FirstName = requestDTO.FirstName,
            LastName = requestDTO.LastName,
            Email = requestDTO.Email,
            PhoneNumber = requestDTO.PhoneNumber,
            Subject = requestDTO.Subject,
            Description = requestDTO.Description,
        };
        return await AddAsync(requestDTO);
    }

    public Task<IEnumerable<Request>> GetComboAsync()
    {
        throw new NotImplementedException();
    }
}