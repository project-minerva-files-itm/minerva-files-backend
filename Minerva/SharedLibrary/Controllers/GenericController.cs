
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.DTOs;
using SharedLibrary.UnitsOfWork.Interfaces;

namespace SharedLibrary.Controllers
{
    public class GenericController<T> : Controller where T : class
    {
        private readonly IGenericUnitOfWork<T> _unitOfWork;

        public GenericController(IGenericUnitOfWork<T> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpPost]
        public virtual async Task<IActionResult> PostAsync(T model)
        {
            var action = await _unitOfWork.AddAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action);
            }
            return BadRequest(action);
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAsync(int id)
        {
            var action = await _unitOfWork.GetAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action.Result);
            }
            return BadRequest();
        }

        [HttpGet("paginated")]
        public virtual async Task<IActionResult> GetAllAsync([FromQuery] PaginationDTO pagination)
        {
            var action = await _unitOfWork.GetAllAsync(pagination);
            if (action.WasSuccess)
            {
                return Ok(action);
            }
            return BadRequest();
        }


        [HttpPut]
        public virtual async Task<IActionResult> PutAsync(T model)
        {
            var action = await _unitOfWork.UpdateAsync(model);
            if (action.WasSuccess)
            {
                return Ok(action);
            }
            return BadRequest(action);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteAsync(int id)
        {
            var action = await _unitOfWork.DeleteAsync(id);
            if (action.WasSuccess)
            {
                return Ok(action);
            }
            return BadRequest(action.Message);
        }

    }
}
