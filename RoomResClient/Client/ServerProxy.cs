using Shared.Communication;
using Shared.Dto;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomResClient.Client
{
    public class ServerProxy : IServerProxy
    {
        public ServerProxy(HubConnection connection)
        {
            Connection = connection;
            Connection.StartAsync().Wait();
        }

        public async Task<List<UserDto>> GetAllUsers()
        {
            try
            {
                return await Connection.InvokeAsync<List<UserDto>>(nameof(IRoomReservationHub.GetAllUsers))
                    .ConfigureAwait(false);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error with executing server method {nameof(IRoomReservationHub.GetAllUsers)}: {e}");
            }

            return await Task.FromResult(new List<UserDto>());
        }

        private HubConnection Connection { get; set; }
    }
}