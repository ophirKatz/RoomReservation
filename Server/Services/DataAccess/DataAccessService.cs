using DAL;
using Serilog;
using Server.Configuration;

namespace Server.Services.DataAccess
{
    public class DataAccessService : IDataAccessService
    {
        #region Constructor

        public DataAccessService(ILogger logger,
            IDatabaseConfiguration databaseConfiguration)
        {
            Logger = logger;
            DatabaseConfiguration = databaseConfiguration;

            Logger.DatabaseConfigured(DatabaseConfiguration);
        }

        #endregion

        #region Implementation of IDataAccessService

        /// <summary>
        /// Use db context as such:
        /// using (var context = DbContextInstance)
        /// </summary>

        #endregion

        #region Private Members

        private ILogger Logger { get; }
        private IDatabaseConfiguration DatabaseConfiguration { get; set; }

        private ServerDbContext DbContextInstance
        {
            get
            {
                if (DatabaseConfiguration == null)
                    return null;

                return new ServerDbContext(DatabaseConfiguration.ServerAddress,
                    DatabaseConfiguration.ServerPort,
                    DatabaseConfiguration.DbName,
                    DatabaseConfiguration.Username,
                    DatabaseConfiguration.Password);
            }
        }

        #endregion
    }
}