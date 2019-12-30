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

  public ngOnInit() {
    this.roomService.fetchRoomsAsync()
      .then((roomDtos: RoomDto[]) => this.setRoomsFromDtos(roomDtos));
  }

  private setRoomsFromDtos(roomDtos: RoomDto[]): void {
    this.rooms = roomDtos.map(roomDto => new Room(roomDto));
  }

  private rooms: Room[];
}
