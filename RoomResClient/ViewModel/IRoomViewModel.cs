using Shared.Data;

namespace RoomResClient.ViewModel
{
    public interface IRoomViewModel
    {
        int Capacity { get; set; }
        string Description { get; set; }
        bool HasComputer { get; set; }
        bool HasSpeaker { get; set; }
        RoomLocation Location { get; set; }
        bool Display { get; set; }

        bool FilterByDescription(string description);
        bool FilterByDesiredCapacity(int numberOfPeople);
    }
}