namespace Shared.Data
{
    public class RoomLocation
    {
        public RoomLocation(string building, int floor, int number)
        {
            Building = building;
            Floor = floor;
            Number = number;
        }

        public string Building { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }

        public override string ToString()
        {
            return $"{nameof(Building)}: {Building}, {nameof(Floor)}: {Floor}, {nameof(Number)}: {Number}";
        }
    }
}