export class RoomLocation {
	public building: string;
	public floor: number;
	public number: number;

	public toString(): string {
		return `${this.building}/${this.floor}/${this.number}`;
	}
}