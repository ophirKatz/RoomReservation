using DAL;
using Server.Configuration;

namespace Server.Services
{
    public class DataAccessService : IDataAccessService
    {
        #region Constructor

        public DataAccessService(IDatabaseConfiguration databaseConfiguration)
        {
            DatabaseConfiguration = databaseConfiguration;
        }

        #endregion

        #region Implementation of IDataAccessService

        /// <summary>
        /// Use db context as such:
        /// using (var context = DbContextInstance)
        /// </summary>

        #endregion

        #region Private Members

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