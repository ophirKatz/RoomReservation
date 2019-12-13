using Microsoft.AspNetCore.SignalR.Client;
using RoomResClient.Extensions;
using Serilog;
using Shared.Communication;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomResClient.Client
{
    public class ServerProxy : IServerProxy
    {
        public ServerProxy(HubConnection connection,
            ILogger logger,
            IRoomReservationClient client)
        {
            Connection = connection;
            // Configure your client connection with all interface methods with this extension method
            client.ConfigureConnection(Connection);
            Logger = logger;
            Connection.StartAsync().Wait();

            Logger.Information("Started connection with server");
        }

        #region Implementation of IServerProxy

        public async Task<List<UserDto>> GetAllUsers()
        {
            try
            {
                return await Connection.InvokeAsync<List<UserDto>>(nameof(IRoomReservationHub.GetAllUsers))
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Logger.Error($"Error with executing server method {nameof(IRoomReservationHub.GetAllUsers)}: {e}");
            }

            return await Task.FromResult(new List<UserDto>());
        }

        public async Task<List<RoomDto>> GetAllRooms()
        {
            try
            {
                return await Connection.InvokeAsync<List<RoomDto>>(nameof(IRoomReservationHub.GetAllRooms))
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Logger.Error($"Error with executing server method {nameof(IRoomReservationHub.GetAllRooms)}: {e}");
            }

            return await Task.FromResult(new List<RoomDto>());
        }

        public async Task<bool> AddNewReservation(ReservationDetails reservationDetails, string username, string roomDescription)
        {
            try
            {
                return await Connection.InvokeAsync<bool>(nameof(IRoomReservationHub.AddNewReservation),
                    reservationDetails, username, roomDescription)
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Logger.Error($"Error with executing server method {nameof(IRoomReservationHub.AddNewReservation)}: {e}");
            }

            return false;
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose()
        {
            Connection.DisposeAsync().Wait();
        }

        #endregion

        #region Private Members

        private HubConnection Connection { get; set; }
        private ILogger Logger { get; }

        #endregion
    }
}