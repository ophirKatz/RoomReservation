using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DbFiller
{
    public class ServerDbContextFactory : IDesignTimeDbContextFactory<ServerDbContext>
    {
        public ServerDbContextFactory()
        {
            var dbConfig = Program.Configure();
            _connectionString = string.Format("Server={0}; Database={1}; User Id={2}; Password={3};Integrated Security=True;",
                dbConfig.ServerAddress,
                dbConfig.DbName,
                dbConfig.Username,
                dbConfig.Password);
        }

        public ServerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServerDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new ServerDbContext(optionsBuilder.Options);
        }

        private readonly string _connectionString;
    }
}