namespace Server.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public string DbName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}