using Common.Communication;
using Common.Dto;
using Microsoft.AspNetCore.SignalR;
using Server.Server;
using System.Collections.Generic;

namespace Server.Hubs
{
    public class RoomReservationHub : Hub<IRoomReservationClient>, IRoomReservationHub
    {
        #region Constructor

        public RoomReservationHub(IClientRequestHandler clientRequestHandler)
        {
            ClientRequestHandler = clientRequestHandler;
        }

        #endregion

        #region Implementation of IRoomReservationHub

        public List<IUserDto> GetAllUsers()
        {
            return ClientRequestHandler.GetAllUsers();
        }

        #endregion

        #region Private Members

        private IClientRequestHandler ClientRequestHandler { get; }

        #endregion
    }
}