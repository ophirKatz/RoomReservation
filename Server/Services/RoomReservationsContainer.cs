using Common.Extensions;
using Common.Model;
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
            Rooms = new ObservableCollection<IRoomModel>()
                .RegisterCollectionChanged(RoomReservationsContainer_CollectionChanged);
            Users = new ObservableCollection<IUserModel>();
            Reservations = new ObservableCollection<IReservationModel>();
        }

        private void RoomReservationsContainer_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            throw new System.NotImplementedException(); 
        }

        #endregion

        #region Implementation of IRoomReservationsContainer

        public ICollection<IRoomModel> Rooms { get; set; }
        public ICollection<IUserModel> Users { get; set; }
        public ICollection<IReservationModel> Reservations { get; set; }

        #endregion
    }
}