import { Component } from "@angular/core";
import { Location } from '@angular/common';

@Component({
  selector: 'app-error404',
  templateUrl: './errorpage.component.html',
  styleUrls: ['./errorpage.component.css']
})
export class Error404Component {
  message: string;
  status: string;

  constructor(private _location: Location) {
    this.message = "Sorry, it looks like we can't find the page you're looking for!";
    this.status = "404 Not Found";
  }

  backClicked() {
    this._location.back();
  }
}