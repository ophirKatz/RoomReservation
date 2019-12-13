using Server.Model;
using Shared.Dto;
using System;

namespace Server.Server.Converters
{
    public class DtoToModelConverter : IDtoToModelConverter
    {
        #region Constructor

        public DtoToModelConverter(IReservationModel.Factory reservationFactory)
        {
            ReservationFactory = reservationFactory;
        }

        #endregion

        #region Implementation of IDtoToModelConverter

        public IReservationModel ConvertReservationDetails(ReservationDetails reservationDetails, IUserModel userModel, IRoomModel roomModel)
        {
            return ReservationFactory(0, reservationDetails.StartTime, reservationDetails.EndTime,
                roomModel, userModel, reservationDetails.RequiredClearance);
        }

        #endregion

        #region Private Members

        private IReservationModel.Factory ReservationFactory { get; }

        #endregion
    }
}