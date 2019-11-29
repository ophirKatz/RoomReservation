using Common.Enums;
using System.Collections.Generic;

namespace DAL.DbEntities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public UserClearance UserClearance { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}