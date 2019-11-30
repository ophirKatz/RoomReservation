using DAL;
using DAL.Configuration;
using Polly;
using Polly.Retry;
using Serilog;
using System;

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

            RetryPolicy = Policy.Handle<Exception>()
                .RetryForeverAsync((e, i, c) => Logger.Information($"Error: {e} on retry #{i}."));
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
        private AsyncRetryPolicy RetryPolicy { get; set; }

        private ServerDbContext DbContextInstance
        {
            get
            {
                if (DatabaseConfiguration == null)
                    return null;

                return new ServerDbContextFactory(DatabaseConfiguration).CreateDbContext(null);
            }
        }

        #endregion
    }
}