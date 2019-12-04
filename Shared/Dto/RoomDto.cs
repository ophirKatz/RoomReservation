using Common.Data;

namespace Common.Dto
{
    public class RoomDto
    {
        #region Constructor(s)

        public RoomDto()
        {

        }

        public RoomDto(string description, RoomLocation location, int capacity, bool hasSpeaker, bool hasComputer)
        {
            Description = description;
            Location = location;
            Capacity = capacity;
            HasSpeaker = hasSpeaker;
            HasComputer = hasComputer;
        }

        #endregion

        public string Description { get; set; }
        public RoomLocation Location { get; set; }
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        public override string ToString()
        {
            return $"{nameof(Description)}: {Description}, {nameof(Location)}: {Location}, {nameof(Capacity)}: {Capacity}";
        }
    }
}