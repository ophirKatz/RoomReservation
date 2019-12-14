using DAL;
using DAL.Configuration;
using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using Serilog;
using Server.Model;
using Server.Services.DataAccess.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services.DataAccess
{
    public class DataAccessService : IDataAccessService
    {
        #region Constructor

        public DataAccessService(ILogger logger,
            IDatabaseConfiguration databaseConfiguration,
            IModelToEntityConverter modelToEntityConverter)
        {
            Logger = logger;
            DatabaseConfiguration = databaseConfiguration;
            ModelToEntityConverter = modelToEntityConverter;
            Logger.DatabaseConfigured(DatabaseConfiguration);

            RetryPolicy = Policy.Handle<DbUpdateConcurrencyException>()
                .RetryForeverAsync((e, i, c) => Logger.Information($"Error: {e} on retry #{i}."));
        }

        #endregion

        #region Implementation of IDataAccessService

        public bool TryGetRoomByDescription(string description, out Room room)
        {
            using (var context = DbContextInstance)
            {
                room = context.Rooms
                    .FirstOrDefault(room => room.Description.Equals(description));
                if (room == null)
                {
                    Logger.Error($"Room with description {description} was not found", description);
                    return false;
                }
            }

            return true;
        }

        public bool TryGetUserByName(string username, out User user)
        {
            user = GetUserByNameAsync(username)
                .GetAwaiter()
                .GetResult();
            if (user == null)
            {
                Logger.Error($"User with username {username} was not found", username);
                return false;
            }

            return true;
        }

        public async Task<List<Reservation>> GetUserReservationsAsync(string username)
        {
            using var context = DbContextInstance;
            return await context.RoomReservations
                .Include(r => r.Initiator)
                .Include(r => r.Room)
                .Where(r => r.Initiator.Username.Equals(username))
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetReservationsForRoomAsync(string description)
        {
            using var context = DbContextInstance;
            return await context.RoomReservations
                .Include(reservation => reservation.Initiator)
                .Include(reservation => reservation.Room)
                .Where(reservation => reservation.Room.Description.Equals(description))
                .ToListAsync();
        }

        public async Task<List<Room>> GetAllRoomsAsync()
        {
            Logger.Information("Getting all rooms from db");
            using var context = DbContextInstance;
            return await context.Rooms.ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            Logger.Information("Getting all users from db");
            using var context = DbContextInstance;
            return await context.Users
                .ToListAsync();
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            Logger.Information("Getting all reservations from db");
            using var context = DbContextInstance;
            return await context.RoomReservations
                .Include(r => r.Room)
                .Include(r => r.Initiator)
                .ToListAsync();
        }

        public async Task<bool> SaveReservation(IReservationModel reservationModel)
        {
            Logger.Information("Saving a new reservation to the DB: {reservation}", reservationModel);
            var reservation = ModelToEntityConverter.ConvertReservationModel(this, reservationModel);
            if (reservation == null)
            {
                Logger.Error("Failed to convert reservation model: {reservation}", reservationModel);
                return false;
            }

            using var context = DbContextInstance;
            context.RoomReservations.Add(reservation);
            await RetryPolicy.ExecuteAsync(async () => await context.SaveChangesAsync());

            Logger.Information("Saved a new reservation to the DB: {reservation}", reservationModel);
            return true;
        }

        #endregion

        #region Private Members

        private async Task<User> GetUserByNameAsync(string username)
        {
            using var context = DbContextInstance;
            return await context.Users
                .FirstOrDefaultAsync(user => user.Username.Equals(username));
        }

        private ILogger Logger { get; }
        private IDatabaseConfiguration DatabaseConfiguration { get; set; }
        private IModelToEntityConverter ModelToEntityConverter { get; }
        private AsyncRetryPolicy RetryPolicy { get; set; }

        private ServerDbContext DbContextInstance
        {
            get
            {
                if (DatabaseConfiguration == null)
                    return null;

                return new ServerDbContextFactory(DatabaseConfiguration).CreateDbContext(null);
            }
        }

        #endregion
    }
}