import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { UserClearance } from 'src/app/common/enums/user-clearance';
import * as moment from 'moment';

@Component({
  selector: 'app-reservation-action',
  templateUrl: './reservation-action.component.html',
  styleUrls: ['./reservation-action.component.css']
})
export class ReservationActionComponent implements OnInit {

  public constructor(private formBuilder: FormBuilder) {
  }
  
  public ngOnInit() {
    this.reservationForm = this.formBuilder.group(ReservationActionComponent.defaultFormData);
  }

  private onSubmit(formData: ReservationFormData): void {
    console.log('formData', formData);
    this.reservationForm.reset();
  }

  private reservationForm: FormGroup;
  
  //#region Form Initialization & controls

  private static now: moment.Moment = moment();

  private static defaultFormData = <ReservationFormData> {
    roomDescription: '',
    startTime: ReservationActionComponent.now,
    endTime: ReservationActionComponent.now,
    userClearance: UserClearance.Basic
  }

  private userClearanceViews = Object.keys(UserClearance)
    .filter(k => typeof UserClearance[k as any] === "number")
    .map(uc => [uc, UserClearance[uc]]);

  //#endregion
}

class ReservationFormData {
  public roomDescription: string;
  public startTime: moment.Moment;
  public endTime: moment.Moment;
  public userClearance: UserClearance;
}