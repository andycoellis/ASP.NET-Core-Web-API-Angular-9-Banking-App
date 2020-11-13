import { Router } from "@angular/router";
import { UserService, UserData } from "../../_services";
import { Component } from "@angular/core";
import { map } from 'rxjs/operators';


@Component({
  selector: "app.user",
  templateUrl: "./user.component.html"
})
export class UserComponent {
  userList: UserData[];
  userID: string;
  blocked: boolean;

  constructor(private _userService: UserService, private _router: Router) {
    this.getAll();
    this.blocked = false;
  }

  getAll() {
    if (this.blocked) {

      this._userService.getLockedUsers().subscribe(data => this.userList = data);
    }
    else {

      this._userService.getUsers().subscribe(data => this.userList = data);
    }
  }

  triggerButton(custID: number) {
    this._userService.lock(custID).subscribe((data) => {
      this.getAll();
      this._router.navigate(["/users"]);
    });;
  }

  showBlocked() {
    this.blocked = !this.blocked;
    this.getAll();
  }
}