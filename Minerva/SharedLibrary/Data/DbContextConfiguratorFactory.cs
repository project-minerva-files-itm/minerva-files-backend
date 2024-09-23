namespace SharedLibrary.Data
{
    public class DbContextConfiguratorFactory
    {
        public static IDbContextConfigurator CreateConfigurator(string provider, string connectionString)
        {
            return provider switch
            {
                "MySQL" => new MySqlDbContextConfigurator(connectionString),
                "SqlServer" => new SqlServerDbContextConfigurator(connectionString),
                _ => throw new NotSupportedException("Provider not supported: "+ provider)
            };
        }
    }
}
