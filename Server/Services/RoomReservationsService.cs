using Serilog;
using Server.Model;
using Server.Server.Converters;
using Server.Services.DataAccess;
using Shared.Dto;
using Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Services
{
    public class RoomReservationsService : IRoomReservationsService
    {
        #region Constructor

        public RoomReservationsService(IDataAccessService dataAccessService,
            IRoomReservationsContainer roomReservationsContainer,
            ILogger logger,
            IDtoToModelConverter dtoToModelConverter)
        {
            DataAccessService = dataAccessService;
            RoomReservationsContainer = roomReservationsContainer;
            Logger = logger;
            DtoToModelConverter = dtoToModelConverter;
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

        public bool AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription)
        {
            if (!RoomReservationsContainer.UserExists(username, out var user))
            {
                Logger.Error("Requested user does not exist");
                return false;
            }
            if (!RoomReservationsContainer.RoomExists(roomDescription, out var room))
            {
                Logger.Error("Requested room does not exist");
                return false;
            }
            if (!ValidateReservationDetails(reservationDetails))
            {
                Logger.Error("Reservation details are invalid");
                return false;
            }

            var reservation = DtoToModelConverter.ConvertReservationDetails(reservationDetails, user, room);
            try
            {
                var result = DataAccessService.SaveReservation(reservation)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                if (!result)
                {
                    Logger.Error("Failed to save a reservation to the DB: {reservation}", reservation);
                    return result;
                }
            }
            catch (Exception e)
            {
                Logger.Error(e, "Failed to save a reservation to the DB: {reservation}", reservation);
                return false;
            }

            Logger.Information("Added new reservation: {reservation}", reservation);
            return true;
        }

        #endregion

        #region Helper Methods

        private bool ValidateReservationDetails(ReservationDetails reservationDetails)
        {
            if (reservationDetails.RequiredClearance == Shared.Enums.UserClearance.Admin) return false;
            return reservationDetails.StartTime.IsBefore(reservationDetails.EndTime);
        }

        #endregion

        #region Private Members

        private IDataAccessService DataAccessService { get; }
        private IRoomReservationsContainer RoomReservationsContainer { get; }
        private ILogger Logger { get; }
        private IDtoToModelConverter DtoToModelConverter { get; }

        #endregion
    }
}