import { UserClearance } from '../common/enums/user-clearance';
import { ReservationDto } from '../common/dto/reservation.dto';

export class Reservation {
	public constructor(reservationDto: ReservationDto) {
		this.roomDescription = reservationDto.room.description;
		this.startTime = reservationDto.details.startTime;
		this.endTime = reservationDto.details.endTime;
		this.requiredClearance = reservationDto.details.requiredClearance;
	}

	public roomDescription: string;
	public startTime: Date;
	public endTime: Date;
	public requiredClearance: UserClearance;
}