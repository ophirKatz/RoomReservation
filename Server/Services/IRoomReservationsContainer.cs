using Server.Model;
using System.Collections.ObjectModel;

namespace Server.Services
{
    public interface IRoomReservationsContainer
    {
        ObservableCollection<IRoomModel> Rooms { get; set; }
        ObservableCollection<IUserModel> Users { get; set; }
        ObservableCollection<IReservationModel> Reservations { get; set; }
    }
}