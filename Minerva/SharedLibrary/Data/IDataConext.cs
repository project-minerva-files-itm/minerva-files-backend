using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Data
{
    public interface IDataConext 
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveAsync(CancellationToken cancellationToken = default);

        void AddEntity<T>(T entity) where T : class;
    }
}
