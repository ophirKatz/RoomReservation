using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ServerDbContext : DbContext
    {
        #region Constructor

        public ServerDbContext(string serverAddress, int serverPort, string dbName, string username, string password)
        {
            SetConnectionString(serverAddress, serverPort, dbName, username, password);
        }

        #endregion

        #region Db Collections

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> RoomReservations { get; set; }

        #endregion

        #region Db Configuration

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Capacity).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(d => d.UserClearance).IsRequired();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequiredClearance).IsRequired();
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.EndTime).IsRequired();
                entity.HasOne(e => e.User).WithMany(user => user.Reservations);
            });
        }

        private void SetConnectionString(string serverAddress, int serverPort, string dbName, string username, string password)
        {
            ConnectionString = string.Format(ConnectionStringFormat, serverAddress, serverPort.ToString(), dbName, username, password);
        }

        #endregion

        private const string ConnectionStringFormat = "Server={0}; Port={1}; Database={2}; Uid={3}; Pwd={4};";
        private string ConnectionString { get; set; }
    }
}