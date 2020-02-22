import { Component, OnInit, Input } from '@angular/core';
import { Room } from 'src/app/model/room';

@Component({
  selector: 'app-room-view',
  templateUrl: './room-view.component.html',
  styleUrls: ['./room-view.component.css']
})
export class RoomViewComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  @Input() private room: Room;
  @Input() private index: number;
}