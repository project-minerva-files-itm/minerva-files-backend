using Microsoft.EntityFrameworkCore;

namespace SharedLibrary.Data
{
    internal class MySqlDbContextConfigurator : IDbContextConfigurator
    {
        private readonly string _connectionString;
        public MySqlDbContextConfigurator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Configure(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
}
