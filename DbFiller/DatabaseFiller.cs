using DAL;
using DAL.Configuration;

namespace DbFiller
{
    public class DatabaseFiller
    {
        // TODO : Add logging
        public DatabaseFiller(IDataReader dataReader, IDatabaseConfiguration databaseConfiguration)
        {
            DataReader = dataReader;
            DatabaseConfiguration = databaseConfiguration;
        }

        public void FillDb()
        {
            using var context = new ServerDbContextFactory(DatabaseConfiguration).CreateDbContext(null);
            context.Database.EnsureCreated();

            var rooms = DataReader.GetRooms();
            var users = DataReader.GetUsers();
            var reservations = DataReader.GetReservations();
            context.Rooms.AddRange(rooms);
            context.Users.AddRange(users);
            context.RoomReservations.AddRange(reservations);
            context.SaveChanges();
        }

        public IDataReader DataReader { get; }
        public IDatabaseConfiguration DatabaseConfiguration { get; }
    }
}