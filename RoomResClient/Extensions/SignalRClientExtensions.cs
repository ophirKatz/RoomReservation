using Microsoft.AspNetCore.SignalR.Client;
using Shared.Extensions;
using System.Threading.Tasks;

namespace RoomResClient.Extensions
{
    public static class SignalRClientExtensions
    {
        /// <summary>
        /// Configures a HubConnection to listen to server notifications to the specified client interface,
        /// and execute the client's instance methods accordingly.
        /// </summary>
        /// <typeparam name="TClient"></typeparam>
        /// <param name="client"></param>
        /// <param name="connection"></param>
        public static void ConfigureConnection<TClient>(this TClient client, HubConnection connection)
        {
            foreach (var method in typeof(TClient).GetTypeDeclaredMethods())
            {
                connection.On(method.Name, method.GetParameterTypes(), InvokeMethodWithParams);

                Task InvokeMethodWithParams(object[] parameters)
                {
                    return (Task)method?.Invoke(client, parameters);
                }
            }
        }
    }
}