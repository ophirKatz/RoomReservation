using Common.Dto;
using System.Collections.Generic;

namespace Common.Communication
{
    public interface IRoomReservationHub
    {
        // TODO : Add all server requests here
        List<UserDto> GetAllUsers();
    }
}