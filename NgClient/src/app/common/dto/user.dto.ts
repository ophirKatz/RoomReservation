import { UserClearance } from '../enums/user-clearance';

export class UserDto {
	public username: string;
	public userClearance: UserClearance;
}