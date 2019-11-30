using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DbEntities
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Description { get; set; }
        public string Building { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Description)}: {Description}, {nameof(Capacity)}: {Capacity}";
        }
    }
}