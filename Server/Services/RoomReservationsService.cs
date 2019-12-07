using Shared.Dto;
using Serilog;
using Server.Services.DataAccess;
using Server.Services.DataAccess.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using Server.Model;
using Server.Server.Converters;

namespace Server.Services
{
    public class RoomReservationsService : IRoomReservationsService
    {
        #region Constructor

        public RoomReservationsService(IDataAccessService dataAccessService,
            IRoomReservationsContainer roomReservationsContainer,
            ILogger logger)
        {
            DataAccessService = dataAccessService;
            RoomReservationsContainer = roomReservationsContainer;
            Logger = logger;
        }

        #endregion

        #region Implementation of IRoomReservationsService

        public List<IUserModel> GetAllUsers()
        {
            return RoomReservationsContainer.Users.ToList();
        }

        public List<IRoomModel> GetAllRooms()
        {
            return RoomReservationsContainer.Rooms.ToList();
        }

        public List<IRoomModel> GetAllAvailableRooms()
        {
            return GetAllAvailableRooms(DateTime.Now);
        }

        public List<IRoomModel> GetAllAvailableRooms(DateTime startTime)
        {
            return GetAllAvailableRooms(startTime, startTime.AddHours(1));
        }

        public List<IRoomModel> GetAllAvailableRooms(DateTime startTime, DateTime endTime)
        {
            return RoomReservationsContainer.Reservations
                .Where(reservation => reservation.StartTime > endTime || reservation.EndTime < startTime)
                .Select(reservation => reservation.Room)
                .ToList();
        }

        #endregion

        #region Private Members

        private IDataAccessService DataAccessService { get; }
        private IRoomReservationsContainer RoomReservationsContainer { get; }
        private ILogger Logger { get; }

        #endregion
    }
}