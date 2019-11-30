using Common.Model;
using Serilog;
using Server.Services.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.Services
{
    public class RoomReservationsService : IRoomReservationsService
    {
        #region Constructor

        public RoomReservationsService(IDataAccessService dataAccessService,
            ILogger logger,
            I)
        {
            DataAccessService = dataAccessService;
            Logger = logger;
        }

        #endregion

        #region Implementation of IRoomReservationsService

        public List<IRoomModel> GetAllAvailableRooms()
        {
            throw new NotImplementedException();
        }

        public List<IRoomModel> GetAllAvailableRooms(DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public List<IRoomModel> GetAllAvailableRooms(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public List<IRoomModel> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public List<IUserModel> GetAllUsers()
        {
            throw new NotImplementedException();
            // return DataAccessService.GetAllUsers().Select(user => );
        }

        #endregion

        #region Private Members

        public IDataAccessService DataAccessService { get; }
        public ILogger Logger { get; }

        #endregion
    }
}