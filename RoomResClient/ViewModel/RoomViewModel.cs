using Shared.Data;
using Shared.Dto;

namespace RoomResClient.ViewModel
{
    public class RoomViewModel : IRoomViewModel
    {
        #region Constructor

        public RoomViewModel(RoomDto roomDto)
        {
            Description = roomDto.Description;
            Location = roomDto.Location;
            Capacity = roomDto.Capacity;
            HasSpeaker = roomDto.HasSpeaker;
            HasComputer = roomDto.HasComputer;
            Display = true;
        }

        #endregion

        #region Implementation of IRoomViewModel

        public string Description { get; set; }
        public RoomLocation Location { get; set; }
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }
        public bool Display { get; set; }
        public bool FilterByDesiredCapacity(int numberOfPeople) => numberOfPeople <= Capacity;
        public bool FilterByDescription(string description) => Description.Contains(description);

        #endregion
    }
}