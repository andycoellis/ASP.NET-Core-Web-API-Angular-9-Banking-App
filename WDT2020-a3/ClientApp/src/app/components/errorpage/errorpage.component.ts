import { Component } from "@angular/core";
import { Location } from '@angular/common';

@Component({
  selector: 'app-errorpage',
  templateUrl: './errorpage.component.html',
  styleUrls: ['./errorpage.component.css']
})
export class ErrorPageComponent{
  message: string;
  status: string;

  constructor(private _location: Location) {
    this.message = "Sorry, it looks like something has happened on our end...";
    this.status = "Unknown Error";
  }

  backClicked() {
    this._location.back();
  }
}