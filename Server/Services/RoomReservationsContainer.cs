using Server.Model;
using Server.Services.DataAccess;
using Server.Services.DataAccess.Converters;
using System.Collections.ObjectModel;
using System.Linq;

namespace Server.Services
{
    public class RoomReservationsContainer : IRoomReservationsContainer
    {
        #region Constructor

        public RoomReservationsContainer(IDataAccessService dataAccessService,
            IEntityToModelConverter entityToModelConverter)
        {
            DataAccessService = dataAccessService;
            EntityToModelConverter = entityToModelConverter;
            
            Users = new ObservableCollection<IUserModel>(DataAccessService.GetAllUsersAsync()
                .GetAwaiter()
                .GetResult()
                .Select(EntityToModelConverter.ConvertUserEntity));
            Rooms = new ObservableCollection<IRoomModel>(DataAccessService.GetAllRoomsAsync()
                .GetAwaiter()
                .GetResult()
                .Select(EntityToModelConverter.ConvertRoomEntity));
            Reservations = new ObservableCollection<IReservationModel>(DataAccessService.GetAllReservationsAsync()
                .GetAwaiter()
                .GetResult()
                .Select(EntityToModelConverter.ConvertReservationEntity));
        }

        #endregion

        #region Implementation of IRoomReservationsContainer

        public ObservableCollection<IRoomModel> Rooms { get; set; }
        public ObservableCollection<IUserModel> Users { get; set; }
        public ObservableCollection<IReservationModel> Reservations { get; set; }

        public bool UserExists(string username, out IUserModel userModel)
        {
            userModel = Users.FirstOrDefault(u => Equals(u.Name, username));
            return userModel != null;
        }

        public bool RoomExists(string description, out IRoomModel roomModel)
        {
            roomModel = Rooms.FirstOrDefault(r => Equals(r.Description, description));
            return roomModel != null;
        }

        #endregion

        #region Private Members

        public IDataAccessService DataAccessService { get; }
        public IEntityToModelConverter EntityToModelConverter { get; }

        #endregion
    }
}