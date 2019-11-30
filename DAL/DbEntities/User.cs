using Common.Enums;
using System.Collections.Generic;

namespace DAL.DbEntities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public UserClearance UserClearance { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}