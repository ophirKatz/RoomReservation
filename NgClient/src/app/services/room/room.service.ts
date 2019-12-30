import { Injectable } from '@angular/core';
import * as signalR from '@aspnet/signalr';
import { HubMethods } from 'src/app/model/hub-methods';
import { RoomDto } from 'src/app/common/dto/room.dto';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  public constructor(private hubConnection: signalR.HubConnection) { }
  
  public async fetchRoomsAsync(): Promise<RoomDto[]> {
    return await this.hubConnection.invoke<RoomDto[]>(HubMethods.getAllRooms)
      .then((roomDtos: RoomDto[]) => roomDtos)
      .catch(error => {
        console.log(`Error with fetching rooms from the server: ${error}`);
        return null;
      });
  }
}
