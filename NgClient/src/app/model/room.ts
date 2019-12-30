import { RoomLocation } from './room-location';
import { RoomDto } from '../common/dto/room.dto';

export class Room {
	public constructor(roomDto: RoomDto) {
		this.description = roomDto.description;
		this.capacity = roomDto.capacity;
		this.hasSpeaker = roomDto.hasSpeaker;
		this.hasComputer = roomDto.hasComputer;
		this.location = roomDto.location;
	}

	description: string;
	capacity: number;
	hasSpeaker: boolean;
	hasComputer: boolean;
	location: RoomLocation;
}