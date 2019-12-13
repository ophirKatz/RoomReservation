using Microsoft.AspNetCore.SignalR;
using Server.Server;
using Shared.Communication;
using Shared.Dto;
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

        public List<UserDto> GetAllUsers()
        {
            return ClientRequestHandler.GetAllUsers();
        }

        public List<RoomDto> GetAllRooms()
        {
            return ClientRequestHandler.GetAllRooms();
        }

        public bool AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription)
        {
            return ClientRequestHandler.AddNewReservation(reservationDetails, username, roomDescription);
        }

        #endregion

        #region Private Members

        private IClientRequestHandler ClientRequestHandler { get; }

        #endregion
    }
}