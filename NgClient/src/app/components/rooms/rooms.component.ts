import { Component, OnInit } from '@angular/core';
import { RoomService } from 'src/app/services/room/room.service';
import { Room } from 'src/app/model/room';
import { RoomDto } from 'src/app/common/dto/room.dto';

@Component({
  selector: 'app-rooms',
  templateUrl: './rooms.component.html',
  styleUrls: ['./rooms.component.css']
})
export class RoomsComponent implements OnInit {
  public constructor(private roomService: RoomService) { }

  public async ngOnInit() {
    this.roomService.fetchRoomsAsync()
      .then((roomDtos: RoomDto[]) => this.setRoomsFromDtos(roomDtos));
  }

  private async setRoomsFromDtos(roomDtos: RoomDto[]) {
    this.rooms = roomDtos.map(roomDto => new Room(roomDto));
  }

  private chooseRoom(room: Room): void {
    console.log(`chose room ${room.description}`);
    this.chosenRoom = room;
  }

  private chosenRoom: Room;
  private rooms: Room[];
}
