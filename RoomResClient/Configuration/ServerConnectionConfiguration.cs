namespace RoomResClient.Configuration
{
    public class ServerConnectionConfiguration : IServerConnectionConfiguration
    {
        public string ServerAddress { get; set; }
        public string ServerHubName { get; set; }
        public int ServerPort { get; set; }
    }
}