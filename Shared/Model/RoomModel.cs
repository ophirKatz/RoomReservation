using Common.Data;

namespace Common.Model
{
    public class RoomModel : IRoomModel
    {
        #region Constructor(s)

        public RoomModel(RoomLocation location, int capacity, bool hasSpeaker, bool hasComputer)
        {
            Location = location;
            Capacity = capacity;
            HasSpeaker = hasSpeaker;
            HasComputer = hasComputer;
        }

        #endregion

        #region Implementation of IRoomModel

        public RoomLocation Location { get; set; }
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Location)}: {Location}, {nameof(Capacity)}: {Capacity}";
        }
    }
}