using Common.Enums;
using DAL.DbEntities;
using EnumsNET;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbFiller
{
    public class JsonDataReader : IDataReader
    {
        #region Constructor

        // TODO : Add logging
        public JsonDataReader(string dataFileName)
        {
            DataFileRoot = new ConfigurationBuilder()
                .AddJsonFile(dataFileName)
                .Build();

            _readFile = false;
        }

        #endregion

        #region Implementation of IDataReader

        public IEnumerable<Reservation> GetReservations()
        {
            return ReadFile().Reservations.Values;
        }

        public IEnumerable<Room> GetRooms()
        {
            return ReadFile().Rooms.Values;
        }

        public IEnumerable<User> GetUsers()
        {
            return ReadFile().Users.Values;
        }

        #endregion

        #region Private Members

        private JsonDataReader ReadFile()
        {
            if (_readFile) return this;

            #region Read Sections

            RoomSections = DataFileRoot.GetSection(nameof(Rooms))
                .GetChildren()
                .ToDictionary(roomSection => roomSection["Id"]);

            UserSections  = DataFileRoot.GetSection(nameof(Users))
                .GetChildren()
                .ToDictionary(userSection => userSection["Id"]);

            ReservationSections = DataFileRoot.GetSection(nameof(Reservations))
                .GetChildren()
                .ToDictionary(reservationSection => reservationSection["Id"]);

            #endregion

            #region Fill Lists

            Rooms = RoomSections.Values.ToDictionary(section => int.Parse(section["Id"]), section => new Room
            {
                Capacity = int.Parse(section["Capacity"]),
                HasSpeaker = bool.Parse(section["HasSpeaker"]),
                HasComputer = bool.Parse(section["HasComputer"])
            });

            Users = UserSections.Values.ToDictionary(section => int.Parse(section["Id"]), section => new User
            {
                Username = section["Username"],
                UserClearance = Enums.Parse<UserClearance>(section["UserClearance"])
            });

            Reservations = ReservationSections.Values.ToDictionary(section => int.Parse(section["Id"]), section => new Reservation
            {
                StartTime = DateTime.Parse(section["StartTime"]),
                EndTime = DateTime.Parse(section["EndTime"]),
                RequiredClearance = Enums.Parse<UserClearance>(section["RequiredClearance"]),
                Initiator = Users.Single(user => user.Key == int.Parse(section["InitiatorId"])).Value,
                Room = Rooms.Single(room => room.Key == int.Parse(section["RoomId"])).Value
            });

            foreach (var userEntry in Users)
            {
                userEntry.Value.Reservations = Reservations.Where(reservation => reservation.Value.Initiator.Id == userEntry.Key)
                    .Select(reservationEntry => reservationEntry.Value)
                    .ToList();
            }

            #endregion

            _readFile = true;
            return this;
        }

        private IConfigurationRoot DataFileRoot { get; set; }
        private bool _readFile;
        
        private Dictionary<string, IConfigurationSection> RoomSections { get; set; }
        private Dictionary<string, IConfigurationSection> UserSections { get; set; }
        private Dictionary<string, IConfigurationSection> ReservationSections { get; set; }

        private Dictionary<int, Room> Rooms { get; set; }
        private Dictionary<int, User> Users { get; set; }
        private Dictionary<int, Reservation> Reservations { get; set; }

        #endregion
    }
}