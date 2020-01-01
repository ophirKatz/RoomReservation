import { UserClearance } from "../enums/user-clearance";
import { RoomDto } from './room.dto';
import { UserDto } from './user.dto';

class ReservationDetails {
	public startTime: Date;
	public endTime: Date;
	public requiredClearance: UserClearance;
}

export class ReservationDto {
	public id: number;
	details: ReservationDetails;
	room: RoomDto;
	user: UserDto;
}