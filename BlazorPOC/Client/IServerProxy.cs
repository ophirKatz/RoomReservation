using Common.Dto;
using System.Collections.Generic;

namespace BlazorPOC.Client
{
    public interface IServerProxy
    {
        // TODO : Add all server proxy calls - these call to the hub methods via HubConnection object
        List<IUserDto> GetAllUsers();
    }
}