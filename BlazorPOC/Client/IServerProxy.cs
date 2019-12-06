using Shared.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorPOC.Client
{
    public interface IServerProxy
    {
        // TODO : Add all server proxy calls - these call to the hub methods via HubConnection object
        Task<List<UserDto>> GetAllUsers();
    }
}