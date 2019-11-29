using Serilog;
using Server.Configuration;

namespace Server.Server
{
    public static class ServerLoggingExtensions
    {
        public static void ServerStarted(this ILogger logger, ServerConfiguration serverConfig)
        {
            logger.Information($"Server started at: {serverConfig}");
        }
    }
}