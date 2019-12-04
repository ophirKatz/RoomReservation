using Common.Dto;
using System.Collections.ObjectModel;

namespace Server.Services
{
    public interface IRoomReservationsContainer
    {
        ObservableCollection<RoomDto> Rooms { get; set; }
        ObservableCollection<UserDto> Users { get; set; }
        ObservableCollection<ReservationDto> Reservations { get; set; }
    }
}