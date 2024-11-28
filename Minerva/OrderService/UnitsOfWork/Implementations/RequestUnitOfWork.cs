using OrderService.Repositories.Interfaces;
using OrderService.UnitsOfWork.Interfaces;
using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;
using SharedLibrary.UnitsOfWork.Implementations;

namespace OrderService.UnitsOfWork.Implementations;

public class RequestUnitOfWork : GenericUnitOfWork<Request>, IRequestUnitOfWork
{
    private readonly IRequestRepository _requestRepository;

    public RequestUnitOfWork(IGenericRepository<Request> repository, IRequestRepository requestRepository) : base(repository)
    {
        _requestRepository = requestRepository;
    }

    public async Task<ActionResponse<Request>> AddAsync(RequestDTO requestDTO) => await _requestRepository.AddAsync(requestDTO);

    public async Task<ActionResponse<IEnumerable<Request>>> GetAsync() => await _requestRepository.GetAsync();

    public override async Task<ActionResponse<Request>> GetAsync(int id) => await _requestRepository.GetAsync(id);

    public async Task<IEnumerable<Request>> GetComboAsync() => await _requestRepository.GetComboAsync();
}