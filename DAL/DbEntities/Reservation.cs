using Common.Enums;
using System;

namespace DAL.DbEntities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public UserClearance RequiredClearance { get; set; }
        public virtual Room Room { get; set; }
        public virtual User User { get; set; }
    }
}