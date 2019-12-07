using Shared.Data;

namespace Server.Model
{
    public interface IRoomModel
    {
        string Description { get; set; }
        RoomLocation Location { get; set; }
        int Capacity { get; set; }
        bool HasSpeaker { get; set; }
        bool HasComputer { get; set; }

        delegate IRoomModel Factory(string description,
            RoomLocation location,
            int capacity,
            bool hasSpeaker,
            bool hasComputer);
    }
}