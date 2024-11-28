using SharedLibrary.DTOs;
using SharedLibrary.Entities;
using SharedLibrary.Responses;

namespace OrderService.Repositories.Interfaces;

public interface IRequestRepository
{
    Task<ActionResponse<Request>> GetAsync(int id);

    Task<ActionResponse<IEnumerable<Request>>> GetAsync();

    Task<IEnumerable<Request>> GetComboAsync();

    Task<ActionResponse<Request>> AddAsync(RequestDTO requestDTO);
}