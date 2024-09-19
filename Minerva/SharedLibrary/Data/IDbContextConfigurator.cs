using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Data
{
    public interface IDbContextConfigurator
    {
        void Configure(DbContextOptionsBuilder optionsBuilder);
    }
}
