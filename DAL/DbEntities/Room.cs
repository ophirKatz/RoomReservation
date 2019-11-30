using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbEntities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        // TODO : add location
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        public override string ToString()
        {
            // TODO : Add location
            return $"{nameof(Id)}: {Id}, {nameof(Capacity)}: {Capacity}";
        }
    }
}