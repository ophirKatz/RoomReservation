using Common.Dto;
using System.Collections.ObjectModel;

namespace Server.Services
{
    public interface IRoomReservationsContainer
    {
        ObservableCollection<IRoomDto> Rooms { get; set; }
        ObservableCollection<IUserDto> Users { get; set; }
        ObservableCollection<IReservationDto> Reservations { get; set; }
    }
}