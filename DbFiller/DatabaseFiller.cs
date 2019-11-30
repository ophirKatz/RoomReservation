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

            context.Rooms.AddRange(DataReader.GetRooms());
            context.Users.AddRange(DataReader.GetUsers());
            context.RoomReservations.AddRange(DataReader.GetReservations());
            context.SaveChanges();
        }

        public IDataReader DataReader { get; }
        public IDatabaseConfiguration DatabaseConfiguration { get; }
    }
}