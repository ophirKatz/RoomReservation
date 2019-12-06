namespace RoomResClient.Configuration
{
    public interface IServerConnectionConfiguration
    {
        string ServerAddress { get; set; }
        string ServerHubName { get; set; }
        int ServerPort { get; set; }
    }
}