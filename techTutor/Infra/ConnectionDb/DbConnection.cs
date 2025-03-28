namespace techTutor.Infra.ConnectionDb
{
    public class DbConnection
    {
        private readonly string _DbConnectionString;

        public DbConnection(IConfiguration configuration)
        {
            _DbConnectionString = configuration.GetSection("ConnectionStrings").GetSection("PostgresConnection").Value;

        }
        public string GetString()
        {
            return _DbConnectionString;
        }
    }
}
