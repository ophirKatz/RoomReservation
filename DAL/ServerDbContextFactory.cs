using DAL.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace DAL
{
    public class ServerDbContextFactory : IDesignTimeDbContextFactory<ServerDbContext>
    {
        #region Constructors

        public ServerDbContextFactory()
            : this(GetDatabaseConfiguration())
        {
        }

        public ServerDbContextFactory(IDatabaseConfiguration dbConfig)
        {
            _connectionString = string.Format(ConnectionStringFormat,
                dbConfig.ServerAddress,
                dbConfig.DbName,
                dbConfig.Username,
                dbConfig.Password);
        }

        public ServerDbContextFactory(IDatabaseConfiguration dbConfig,
            ILogger logger)
        {
            _connectionString = string.Format(ConnectionStringFormat,
                dbConfig.ServerAddress,
                dbConfig.DbName,
                dbConfig.Username,
                dbConfig.Password);
            Logger = logger;
        }

        #endregion

        public ServerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServerDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ServerDbContext(optionsBuilder.Options, Logger);
        }

        #region Private Members

        private static IDatabaseConfiguration GetDatabaseConfiguration() => new ConfigurationBuilder()
                  .AddJsonFile("config.json")
                  .Build()
                  .GetSection(nameof(DatabaseConfiguration))
                  .Get<DatabaseConfiguration>();

        private readonly string _connectionString;
        private const string ConnectionStringFormat = "Server={0}; Database={1}; User Id={2}; Password={3};Integrated Security=True;";

        private ILogger Logger { get; }

        #endregion
    }
}