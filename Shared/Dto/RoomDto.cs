using Common.Data;

namespace Common.Dto
{
    public class RoomDto : IRoomDto
    {
        #region Constructor(s)

        public RoomDto(string description, RoomLocation location, int capacity, bool hasSpeaker, bool hasComputer)
        {
            Description = description;
            Location = location;
            Capacity = capacity;
            HasSpeaker = hasSpeaker;
            HasComputer = hasComputer;
        }

        #endregion

        #region Implementation of IRoomModel

        public string Description { get; set; }
        public RoomLocation Location { get; set; }
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        #endregion

        public override string ToString()
        {
            return $"{nameof(Description)}: {Description}, {nameof(Location)}: {Location}, {nameof(Capacity)}: {Capacity}";
        }
    }
}