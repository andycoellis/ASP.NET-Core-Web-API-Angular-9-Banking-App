import { Component } from "@angular/core";
import { Location } from '@angular/common';

@Component({
  selector: 'app-error401',
  templateUrl: './errorpage.component.html',
  styleUrls: ['./errorpage.component.css']
})
export class Error401Component {
  message: string;
  status: string;

  constructor(private _location: Location) {
    this.message = "Sorry, you are not authorised!";
    this.status = "401 Not Authorised";
  }

  backClicked() {
    this._location.back();
  }
}