using DAL;
using DAL.Configuration;
using Polly;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DbFiller
{
    public class DatabaseFiller
    {
        public DatabaseFiller(string dataFileName,
            Func<string, IDataReader> dataReaderFactory,
            IDatabaseConfiguration databaseConfiguration,
            ILogger logger)
        {
            DataReader = dataReaderFactory(dataFileName);
            DatabaseConfiguration = databaseConfiguration;
            Logger = logger;

            Logger.Information("Starting {ProjectName} with config file: {fileName}", nameof(DatabaseFiller), dataFileName);
        }

        public async Task Execute()
        {
            using var context = new ServerDbContextFactory(DatabaseConfiguration).CreateDbContext(null);
            Logger.Information("Connected to database with settings: {DbSettings}", DatabaseConfiguration);
            context.Database.EnsureCreated();

            ClearDb(context);
            await FillDb(context);
        }

        public void ClearDb(ServerDbContext context)
        {
            Logger.Information("Clearing the database...");

            context.ClearDb(out var deletedRooms, out var deletedUsers, out var deletedReservations);
            Logger.Information("Deleted {number} room entries...", deletedRooms);
            Logger.Information("Deleted {number} user entries...", deletedUsers);
            Logger.Information("Deleted {number} reservation entries...", deletedReservations);
        }

        public async Task FillDb(ServerDbContext context)
        {
            var rooms = DataReader.GetRooms();
            var users = DataReader.GetUsers();
            var reservations = DataReader.GetReservations();

            context.Rooms.AddRange(rooms);
            context.Users.AddRange(users);
            context.RoomReservations.AddRange(reservations);
            Logger.Information("Added all data to the db context");

            await Policy.Handle<Exception>()
                .RetryForeverAsync((e, i, c) => Logger.Information($"Error: {e} on retry #{i}."))
                .ExecuteAsync(async () => await context.SaveChangesAsync());
            Logger.Information("Saved all data to the db context");
        }

        public IDataReader DataReader { get; }
        public IDatabaseConfiguration DatabaseConfiguration { get; }
        public ILogger Logger { get; }
    }
}