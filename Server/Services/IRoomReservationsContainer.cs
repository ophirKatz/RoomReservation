using Common.Model;
using System.Collections.Generic;

namespace Server.Services
{
    public interface IRoomReservationsContainer
    {
        ICollection<IRoomModel> Rooms { get; set; }
        ICollection<IUserModel> Users { get; set; }
        ICollection<IReservationModel> Reservations { get; set; }
    }
}