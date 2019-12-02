using Common.Dto;
using Serilog;
using Server.Services;
using System.Collections.Generic;

namespace Server.Server
{
    public class ClientRequestHandler : IClientRequestHandler
    {
        #region Constructor

        public ClientRequestHandler(IRoomReservationsService roomReservationsService,
            ILogger logger)
        {
            RoomReservationsService = roomReservationsService;
            logger.Information("Started listening to client requests");
        }

        #endregion

        #region Implementation of IClientRequestHandler

        public List<IUserDto> GetAllUsers()
        {
            return RoomReservationsService.GetAllUsers();
        }

        #endregion

        #region Private Members

        private IRoomReservationsService RoomReservationsService { get; }

        #endregion
    }
}