using Microsoft.AspNetCore.SignalR;
using Server.Server;
using Shared.Communication;
using Shared.Data.Auth.Response;
using Shared.Dto;
using Shared.Dto.Auth.Request;
using System.Collections.Generic;

namespace Server.Hubs
{
    public class RoomReservationHub : Hub<IRoomReservationClient>, IRoomReservationHub, IAuthHub
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

        #region Implementation of IAuthHub

        public LoginResult Login(LoginData loginData)
        {
            return new LoginResult
            {
                Result = Shared.Enums.AuthResult.Success,
                Token = "token"
            };
        }

        public RegisterResult Register(RegisterData registerData)
        {
            return new RegisterResult
            {
                Result = Shared.Enums.AuthResult.Success
            };
        }

        #endregion

        #region Private Members

        private IClientRequestHandler ClientRequestHandler { get; }

        #endregion
    }
}