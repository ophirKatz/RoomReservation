using Serilog;
using Server.Configuration;

namespace Server.Services.DataAccess
{
    public static class DataAccessLoggingExtensions
    {
        public static void DatabaseConfigured(this ILogger logger, IDatabaseConfiguration dbConfig)
        {
            logger.Information($"Database connection was configured: {dbConfig}");
        }
    }
}