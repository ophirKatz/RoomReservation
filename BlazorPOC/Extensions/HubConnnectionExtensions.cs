using Shared.Extensions;
using Microsoft.AspNetCore.SignalR.Client;
using System.Threading.Tasks;

namespace RoomResClient.Extensions
{
    public static class HubConnnectionExtensions
    {
        public static void ConfigureClient<TClient>(this HubConnection connection, TClient client)
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