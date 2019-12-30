import { RoomLocation } from 'src/app/model/room-location';

export interface RoomDto {
	description: string;
	capacity: number;
	hasSpeaker: boolean;
	hasComputer: boolean;
	location: RoomLocation;
}