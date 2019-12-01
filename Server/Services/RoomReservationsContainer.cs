using Common.Extensions;
using Common.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Server.Services
{
    public class RoomReservationsContainer : IRoomReservationsContainer
    {
        #region Constructor

        public RoomReservationsContainer()
        {
            Rooms = new ObservableCollection<IRoomDto>();
            Users = new ObservableCollection<IUserDto>();
            Reservations = new ObservableCollection<IReservationDto>();
        }

        #endregion

        #region Implementation of IRoomReservationsContainer

        public ObservableCollection<IRoomDto> Rooms { get; set; }
        public ObservableCollection<IUserDto> Users { get; set; }
        public ObservableCollection<IReservationDto> Reservations { get; set; }

        #endregion
    }
}