using Common.Data;

namespace Common.Model
{
    public interface IRoomModel
    {
        string Description { get; set; }
        RoomLocation Location { get; set; }
        int Capacity { get; set; }
        bool HasSpeaker { get; set; }
        bool HasComputer { get; set; }
    }
}