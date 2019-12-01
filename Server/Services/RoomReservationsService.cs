using Common.Dto;
using Serilog;
using Server.Services.DataAccess;
using Server.Services.DataAccess.Converters;
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
            IEntityToDtoConverter entityToDtoConverter)
        {
            DataAccessService = dataAccessService;
            Logger = logger;
            EntityToDtoConverter = entityToDtoConverter;
        }

        #endregion

        #region Implementation of IRoomReservationsService

        public List<IRoomDto> GetAllAvailableRooms()
        {
            throw new NotImplementedException();
        }

        public List<IRoomDto> GetAllAvailableRooms(DateTime startTime)
        {
            throw new NotImplementedException();
        }

        public List<IRoomDto> GetAllAvailableRooms(DateTime startTime, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public List<IRoomDto> GetAllRooms()
        {
            throw new NotImplementedException();
        }

        public List<IUserDto> GetAllUsers()
        {
            Logger.Information("Getting all users from db...");
            return DataAccessService.GetAllUsers()
                .Select(user => EntityToDtoConverter.ConvertUserEntity(user))
                .ToList();
        }

        #endregion

        #region Private Members

        private IDataAccessService DataAccessService { get; }
        private ILogger Logger { get; }
        private IEntityToDtoConverter EntityToDtoConverter { get; }

        #endregion
    }
}