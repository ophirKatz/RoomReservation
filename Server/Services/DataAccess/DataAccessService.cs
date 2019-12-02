using DAL;
using DAL.Configuration;
using DAL.DbEntities;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using Serilog;
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
            IDatabaseConfiguration databaseConfiguration)
        {
            Logger = logger;
            DatabaseConfiguration = databaseConfiguration;

            Logger.DatabaseConfigured(DatabaseConfiguration);

            RetryPolicy = Policy.Handle<Exception>()
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
            var user = await GetUserByNameAsync(username);
            return user?.Reservations;
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
            using var context = DbContextInstance;
            return await context.Rooms.ToListAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            using var context = DbContextInstance;
            return await context.Users
                .Include(u => u.Reservations)
                .ToListAsync();
        }

        #endregion

        #region Private Members

        private async Task<User> GetUserByNameAsync(string username)
        {
            using var context = DbContextInstance;
            return await context.Users
                .Include(user => user.Reservations)
                .FirstOrDefaultAsync(user => user.Username.Equals(username));
        }

        private ILogger Logger { get; }
        private IDatabaseConfiguration DatabaseConfiguration { get; set; }
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