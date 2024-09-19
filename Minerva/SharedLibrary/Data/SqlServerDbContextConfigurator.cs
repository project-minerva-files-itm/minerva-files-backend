using Microsoft.EntityFrameworkCore;


namespace SharedLibrary.Data
{

    internal class SqlServerDbContextConfigurator : IDbContextConfigurator
    {
        private readonly string _connectionString;

        public SqlServerDbContextConfigurator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
