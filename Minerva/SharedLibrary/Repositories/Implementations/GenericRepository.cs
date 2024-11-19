using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SharedLibrary.Data;
using SharedLibrary.DTOs;
using SharedLibrary.Helpers;
using SharedLibrary.Repositories.Interfaces;
using SharedLibrary.Responses;



namespace SharedLibrary.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDataConext _context;
        private readonly DbSet<T> _entity;

        public GenericRepository(IDataConext context)
        {
            _context = context;
            _entity = context.Set<T>();
        }

        public virtual async Task<ActionResponse<T>> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);

            try
            {
                await _context.SaveAsync();
                return  new ActionResponse<T>.ActionResponseBuilder().SetMessage("Saved record").SetResult(entity).Build();
     
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }

        public virtual async Task<ActionResponse<T>> DeleteAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row == null)
            {
                return new ActionResponse<T>.ActionResponseBuilder().SetSuccess(false).SetMessage("ERR001").Build();
            }

            try
            {
                _entity.Remove(row);
                await _context.SaveAsync();
                return new ActionResponse<T>.ActionResponseBuilder().SetMessage("Deleted record").Build();
             
            }
            catch
            {
                return new ActionResponse<T>.ActionResponseBuilder().SetSuccess(false).SetMessage("ERR002").Build();
            }
        }

        public virtual async Task<ActionResponse<T>> GetAsync(int id)
        {
            var row = await _entity.FindAsync(id);
            if (row != null)
            {
                return new ActionResponse<T>.ActionResponseBuilder().SetResult(row).Build();
            }

            return new ActionResponse<T>.ActionResponseBuilder().SetSuccess(false).SetMessage("ERR001").Build();

        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();

            if (pagination.Filter!=null) {
               queryable= queryable.GetFilteredDataAsync(pagination.Filter??"");
            }

            var result = await queryable.Paginate(pagination).ToListAsync();

            if (pagination.Total=="") {
                pagination.Total= await GetTotalRecordsAsync();
            }

            if (!result.IsNullOrEmpty()) {
                return new ActionResponse<IEnumerable<T>>.ActionResponseBuilder().SetPagination(pagination).SetResult(result).Build();
            }

             return new ActionResponse<IEnumerable<T>>.ActionResponseBuilder().SetMessage("ERR001").Build();
        }

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync()
        {
            return new ActionResponse<IEnumerable<T>>.ActionResponseBuilder()
                .SetResult(await _entity.ToListAsync()).Build();
        }

        public virtual async Task<ActionResponse<T>> UpdateAsync(T entity)
        {
            try
            {
                _context.UpdateEntity(entity);
                await _context.SaveAsync();
                return new ActionResponse<T>.ActionResponseBuilder().SetMessage("Updated record").SetResult(entity).Build();
               
            }
            catch (DbUpdateException)
            {
                return DbUpdateExceptionActionResponse();
            }
            catch (Exception exception)
            {
                return ExceptionActionResponse(exception);
            }
        }


        private  async Task<string> GetTotalRecordsAsync()
        {
            var queryable = _entity.AsQueryable();
            return (await queryable.CountAsync()).ToString();
        }

        private ActionResponse<T> ExceptionActionResponse(Exception exception)
        {
            return new ActionResponse<T>.ActionResponseBuilder().SetMessage(exception.Message).Build();
        }

        private ActionResponse<T> DbUpdateExceptionActionResponse()
        {
            return new ActionResponse<T>.ActionResponseBuilder().SetMessage("ERR003").Build();
        }

      

       

    }
}
