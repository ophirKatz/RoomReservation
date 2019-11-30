namespace DAL.Configuration
{
    public interface IDatabaseConfiguration
    {
        string ServerAddress { get; set; }
        int ServerPort { get; set; }
        string DbName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}