using Microsoft.AspNetCore.Mvc;
using OrderService.UnitsOfWork.Interfaces;
using SharedLibrary.Controllers;
using SharedLibrary.Entities;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace OrderService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequestController : GenericController<Request>
{
    private readonly IRequestUnitOfWork _requestUnitOfWork;

    public RequestController(IGenericUnitOfWork<Request> unitOfWork, IRequestUnitOfWork requestUnitOfWork) : base(unitOfWork)
    {
        _requestUnitOfWork = requestUnitOfWork;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var response = await _requestUnitOfWork.GetAsync();
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return BadRequest();
    }

    [HttpGet("combo")]
    public async Task<IActionResult> GetComboAsync()
    {
        return Ok(await _requestUnitOfWork.GetComboAsync());
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var response = await _requestUnitOfWork.GetAsync(id);
        if (response.WasSuccess)
        {
            return Ok(response.Result);
        }
        return NotFound(response.Message);
    }
}