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
            using (var context = DbContextInstance)
            {
                user = context.Users
                    .Include(user => user.Reservations)
                    .FirstOrDefault(user => user.Username.Equals(username));
                if (user == null)
                {
                    Logger.Error($"User with username {username} was not found", username);
                    return false;
                }
            }

            return true;
        }

        public List<Reservation> GetUserReservations(string username)
        {
            if (!TryGetUserByName(username, out var user)) return null;
            return user.Reservations;
        }

        public List<Reservation> GetReservationsForRoom(string description)
        {
            using (var context = DbContextInstance)
            {
                return context.RoomReservations
                    .Include(reservation => reservation.Initiator)
                    .Include(reservation => reservation.Room)
                    .Where(reservation => reservation.Room.Description.Equals(description))
                    .ToList();
            }
        }

        public List<Room> GetAllRooms()
        {
            using var context = DbContextInstance;
            return context.Rooms.ToList();
        }

        public List<User> GetAllUsers()
        {
            using var context = DbContextInstance;
            return context.Users.ToList();
        }

        #endregion

        #region Private Members

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