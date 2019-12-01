using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DAL
{
    public class ServerDbContext : DbContext
    {
        #region Constructor

        public ServerDbContext(DbContextOptions<ServerDbContext> options)
            : base(options)
        {
        }

        public ServerDbContext(DbContextOptions<ServerDbContext> options,
            ILogger logger)
            : this(options)
        {
            Logger = logger;
        }

        #endregion

        #region Db Collections

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> RoomReservations { get; set; }

        #endregion

        public void ClearDb()
        {
            var deletedReservations = Database.ExecuteSqlRaw($"delete from {nameof(RoomReservations)}");
            var deletedRooms = Database.ExecuteSqlRaw($"delete from {nameof(Rooms)}");
            var deletedUsers = Database.ExecuteSqlRaw($"delete from {nameof(Users)}");

            if (Logger == null) return;
            Logger.Information("Deleted {number} reservation entries...", deletedReservations);
            Logger.Information("Deleted {number} room entries...", deletedRooms);
            Logger.Information("Deleted {number} user entries...", deletedUsers);
        }

        #region Db Configuration

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Capacity).IsRequired();
                entity.HasIndex(e => e.Description).IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Username).IsRequired();
                entity.Property(d => d.UserClearance).IsRequired();
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.RequiredClearance).IsRequired();
                entity.Property(e => e.StartTime).IsRequired();
                entity.Property(e => e.EndTime).IsRequired();
                entity.HasOne(e => e.Initiator).WithMany(user => user.Reservations);
            });
        }

        #endregion

        #region Private Members

        private ILogger Logger { get; }

        #endregion
    }
}