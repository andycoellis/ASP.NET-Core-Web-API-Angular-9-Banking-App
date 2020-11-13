import { UserService, CustomerService, UserData, CustomerData } from "../../_services";
import { Component } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Location } from '@angular/common';


@Component({
  selector: "app.users.details",
  templateUrl: "./details.component.html",
  styleUrls: ["./details.component.css"]
})
export class UserDetailsComponent {
  user: UserData;
  customer: CustomerData;

  constructor(
    private _userService: UserService,
    private _customerService: CustomerService,
    private route: ActivatedRoute,
    private _router: Router,
    private _location: Location
  ) {
    this.getUser(parseInt(this.route.snapshot.paramMap.get('id')));
    this.getCustomer(this.route.snapshot.paramMap.get('id'));
  }

  getUser(id: number) {
    this._userService.getLogin(id).subscribe(data => this.user = data);
  }

  getCustomer(id: string) {
    this._customerService.getCustomer(id).subscribe(data => this.customer = data);
  }

  triggerButton() {
    this._userService.lock(this.user.customerId).subscribe((data) => {
      this._router.navigate(["/users"]);
    });;
  }

  backClicked() {
    this._location.back();
  }

}