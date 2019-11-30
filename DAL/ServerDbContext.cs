using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ServerDbContext : DbContext
    {
        #region Constructor

        public ServerDbContext(DbContextOptions<ServerDbContext> options)
            : base(options)
        {
        }

        #endregion

        #region Db Collections

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> RoomReservations { get; set; }

        #endregion

        public void ClearDb(out int deletedRooms, out int deletedUsers, out int deletedReservations)
        {
            deletedReservations = Database.ExecuteSqlRaw($"delete from {nameof(RoomReservations)}");
            deletedRooms = Database.ExecuteSqlRaw($"delete from {nameof(Rooms)}");
            deletedUsers = Database.ExecuteSqlRaw($"delete from {nameof(Users)}");
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
    }
}