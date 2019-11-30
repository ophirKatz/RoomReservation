﻿namespace DAL.DbEntities
{
    public class Room
    {
        public int Id { get; set; }
        // TODO : add location
        public int Capacity { get; set; }
        public bool HasSpeaker { get; set; }
        public bool HasComputer { get; set; }

        public override string ToString()
        {
            // TODO : Add location
            return $"{nameof(Id)}: {Id}, {nameof(Capacity)}: {Capacity}";
        }
    }
}