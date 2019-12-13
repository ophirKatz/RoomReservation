using Shared.Dto;
using Serilog;
using Server.Services;
using System.Collections.Generic;
using Server.Server.Converters;
using System.Linq;

namespace Server.Server
{
    public class ClientRequestHandler : IClientRequestHandler
    {
        #region Constructor

        public ClientRequestHandler(IRoomReservationsService roomReservationsService,
            IModelToDtoConverter modelToDtoConverter,
            ILogger logger)
        {
            RoomReservationsService = roomReservationsService;
            ModelToDtoConverter = modelToDtoConverter;
            logger.Information("Started listening to client requests");
        }

        #endregion

        #region Implementation of IClientRequestHandler

        public List<UserDto> GetAllUsers()
        {
            return RoomReservationsService.GetAllUsers()
                .Select(ModelToDtoConverter.ConvertUserModelToDto)
                .ToList();
        }

        public List<RoomDto> GetAllRooms()
        {
            return RoomReservationsService.GetAllRooms()
                .Select(ModelToDtoConverter.ConvertRoomModelToDto)
                .ToList();
        }

        public bool AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription)
        {
            return RoomReservationsService.AddNewReservation(reservationDetails,
                username,
                roomDescription);
        }

        #endregion

        #region Private Members

        private IRoomReservationsService RoomReservationsService { get; }
        private IModelToDtoConverter ModelToDtoConverter { get; }

        #endregion
    }
}