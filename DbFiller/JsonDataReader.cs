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
            return ReadFile().Reservations;
        }

        public IEnumerable<Room> GetRooms()
        {
            return ReadFile().Rooms;
        }

        public IEnumerable<User> GetUsers()
        {
            return ReadFile().Users;
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

            Rooms = RoomSections.Values.Select(section => section.Get<Room>()).ToList();

            Users = UserSections.Values.Select(userSection => {
                var newUser = new User
                {
                    Id = int.Parse(userSection["Id"]),
                    Username = userSection["Username"],
                    UserClearance = Enums.Parse<UserClearance>(userSection["UserClearance"])
                };
                return newUser;
            }).ToList();

            Reservations = ReservationSections.Values.Select(reservationSection => new Reservation
            {
                Id = int.Parse(reservationSection["Id"]),
                StartTime = DateTime.Parse(reservationSection["StartTime"]),
                EndTime = DateTime.Parse(reservationSection["EndTime"]),
                RequiredClearance = Enums.Parse<UserClearance>(reservationSection["RequiredClearance"]),
                Initiator = Users.Single(user => user.Id == int.Parse(reservationSection["InitiatorId"])),
                Room = Rooms.Single(room => room.Id == int.Parse(reservationSection["RoomId"]))
            }).ToList();

            Users.ForEach(user => user.Reservations = Reservations.Where(reservation => reservation.Initiator.Id == user.Id).ToList());

            #endregion

            _readFile = true;
            return this;
        }

        private IConfigurationRoot DataFileRoot { get; set; }
        private bool _readFile;
        
        private Dictionary<string, IConfigurationSection> RoomSections { get; set; }
        private Dictionary<string, IConfigurationSection> UserSections { get; set; }
        private Dictionary<string, IConfigurationSection> ReservationSections { get; set; }

        private List<Room> Rooms { get; set; }
        private List<User> Users { get; set; }
        private List<Reservation> Reservations { get; set; }

        #endregion
    }
}