using Microsoft.EntityFrameworkCore;
using SharedLibrary.Data;
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
                return  new ActionResponse<T>.ActionResponseBuilder().SetResult(entity).Build();
     
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
                return new ActionResponse<T>.ActionResponseBuilder().Build();
             
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
                return new ActionResponse<T>.ActionResponseBuilder().SetResult(entity).Build();
               
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

        /*
        

        public virtual async Task<ActionResponse<IEnumerable<T>>> GetAsync(PaginationDTO pagination)
        {
            var queryable = _entity.AsQueryable();

            return new ActionResponse<IEnumerable<T>>
            {
                WasSuccess = true,
                Result = await queryable
                    .Paginate(pagination)
                    .ToListAsync()
            };
        }

        public virtual async Task<ActionResponse<int>> GetTotalRecordsAsync()
        {
            var queryable = _entity.AsQueryable();
            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }

        */

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
