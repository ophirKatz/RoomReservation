namespace DAL.Configuration
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public string ServerAddress { get; set; }
        public int ServerPort { get; set; }
        public string DbName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"{nameof(ServerAddress)}: {ServerAddress}, {nameof(ServerPort)}: {ServerPort}, {nameof(DbName)}: {DbName}";
        }
    }
}