using Common.Dto;
using DAL.DbEntities;
using System.Linq;

namespace Server.Services.DataAccess.Converters
{
    public class DtoToEntityConverter : IDtoToEntityConverter
    {
        #region Constructor

        public DtoToEntityConverter(IDataAccessService dataAccessService)
        {
            DataAccessService = dataAccessService;
        }

        #endregion

        #region Implementation of IDtoToEntityConverter

        public Reservation ConvertReservationDto(IReservationDto reservationDto)
        {
            if (!DataAccessService.TryGetRoomByDescription(reservationDto.Room.Description, out var room))
            {
                room = ConvertRoomDto(reservationDto.Room);
            }

            if (!DataAccessService.TryGetUserByName(reservationDto.Initiator.Name, out var user))
            {
                user = ConvertUserDto(reservationDto.Initiator);
            }

            return new Reservation
            {
                StartTime = reservationDto.StartTime,
                EndTime = reservationDto.EndTime,
                RequiredClearance = reservationDto.RequiredClearance,
                Room = room,
                Initiator = user
            };
        }

        public Room ConvertRoomDto(IRoomDto roomDto)
        {
            return new Room
            {
                Description = roomDto.Description,
                Building = roomDto.Location.Building,
                Floor = roomDto.Location.Floor,
                Number = roomDto.Location.Number,
                Capacity = roomDto.Capacity,
                HasSpeaker = roomDto.HasSpeaker,
                HasComputer = roomDto.HasComputer
            };
        }

        public User ConvertUserDto(IUserDto userDto)
        {
            var reservations = DataAccessService.GetUserReservationsAsync(userDto.Name)
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
            if (reservations == null)
            {
                reservations = userDto.RoomReservations.Select(res => ConvertReservationDto(res)).ToList();
            }

            return new User
            {
                Username = userDto.Name,
                UserClearance = userDto.UserClearance,
                Reservations = reservations
            };
        }

        #endregion

        #region Private Members

        public IDataAccessService DataAccessService { get; }

        #endregion
    }
}