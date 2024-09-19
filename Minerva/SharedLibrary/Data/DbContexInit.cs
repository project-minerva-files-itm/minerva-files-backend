using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace SharedLibrary.Data
{
    public class DbContexInit
    {
        private readonly IConfiguration _configuration;

        public DbContexInit(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbContextConfigurator ConfigureServices(IServiceCollection services)
        {
            var provider = _configuration["DatabaseProvider"];
            var connectionString = _configuration.GetConnectionString(provider == "MySQL" ? "MySqlConnection" : "SqlServerConnection");
            return DbContextConfiguratorFactory.CreateConfigurator(provider??"", connectionString??"");

        }
    }
}
