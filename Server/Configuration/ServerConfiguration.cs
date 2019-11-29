namespace Server.Configuration
{
    public class ServerConfiguration : IServerConfiguration
    {
        public string ServerAddress { get; set; }

        public override string ToString()
        {
            return $"{nameof(ServerAddress)}: {ServerAddress}";
        }
    }
}