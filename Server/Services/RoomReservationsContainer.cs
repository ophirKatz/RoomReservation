using Common.Dto;
using System.Collections.ObjectModel;

namespace Server.Services
{
    public class RoomReservationsContainer : IRoomReservationsContainer
    {
        #region Constructor

        public RoomReservationsContainer()
        {
            Rooms = new ObservableCollection<RoomDto>();
            Users = new ObservableCollection<UserDto>();
            Reservations = new ObservableCollection<ReservationDto>();
        }

        #endregion

        #region Implementation of IRoomReservationsContainer

        public ObservableCollection<RoomDto> Rooms { get; set; }
        public ObservableCollection<UserDto> Users { get; set; }
        public ObservableCollection<ReservationDto> Reservations { get; set; }

        #endregion
    }
}