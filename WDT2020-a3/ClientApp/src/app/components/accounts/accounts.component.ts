import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { AccountService, AccountData } from "../../_services";

@Component({
    selector: "app.accounts",
    templateUrl: "./accounts.component.html"
})
export class AccountsComponent {
    accountsList: AccountData[];
    customerId: string;

    constructor(private _accountService: AccountService, private route: ActivatedRoute) {
        this.customerId = this.route.snapshot.paramMap.get('id');
        this.getCustomerAccounts(this.customerId);
    }

    getCustomerAccounts(id: string) {
        this._accountService.getCustomerAccounts(id).subscribe(data => this.accountsList = data);
    }
}