import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UserClearance } from 'src/app/common/enums/user-clearance';

@Component({
  selector: 'app-reservation-action',
  templateUrl: './reservation-action.component.html',
  styleUrls: ['./reservation-action.component.css']
})
export class ReservationActionComponent implements OnInit {
  public constructor(private formBuilder: FormBuilder) {
    this.reservationForm = this.formBuilder.group(ReservationActionComponent.defaultFormData);
  }

  public ngOnInit() {
  }

  private reservationForm: FormGroup;

  private static defaultFormData = {
    roomDescription: '',
    userClearance: UserClearance.Basic
  }
}
