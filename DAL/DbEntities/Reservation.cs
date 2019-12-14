using Shared.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbEntities
{
    public class Reservation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public UserClearance RequiredClearance { get; set; }
        public virtual Room Room { get; set; }
        public int RoomId { get; set; }
        public virtual User Initiator { get; set; }
        public int InitiatorId { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Room)}: {RoomId}, {nameof(Initiator)}: {InitiatorId}";
        }
    }
}