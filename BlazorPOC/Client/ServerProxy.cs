using Common.Communication;
using Common.Dto;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;

namespace BlazorPOC.Client
{
    public class ServerProxy : IServerProxy
    {
        public ServerProxy(HubConnection connection)
        {
            Connection = connection;
            Connection.StartAsync();
        }

        public List<IUserDto> GetAllUsers()
        {
            try
            {
                return Connection.InvokeAsync<List<IUserDto>>(nameof(IRoomReservationHub.GetAllUsers))
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error with executing server method {nameof(IRoomReservationHub.GetAllUsers)}: {e}");
            }

            return null;
        }

        private HubConnection Connection { get; set; }
    }
}