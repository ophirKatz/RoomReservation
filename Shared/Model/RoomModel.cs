using Common.Data;

namespace Common.Model
{
    public class RoomModel : IRoomModel
    {
        #region Constructor(s)

        public RoomModel(int id, RoomLocation location, int capacity, bool hasSpeaker, bool hasComputer)
        {
            Id = id;
            Location = location;
            Capacity = capacity;
            HasSpeaker = hasSpeaker;
            HasComputer = hasComputer;
        }

        #endregion

        public int Id { get; set; }
        public RoomLocation Location { get; set; }
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Location)}: {Location}, {nameof(Capacity)}: {Capacity}";
        }
    }
}