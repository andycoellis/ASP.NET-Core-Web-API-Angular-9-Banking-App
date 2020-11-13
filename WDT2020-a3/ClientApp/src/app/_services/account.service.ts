import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

export interface AccountData {
    accountNumber: number;
    accountType: string;
    customerId: number;
    balance: number;
    modifyDate: Date;
}

@Injectable({ providedIn: 'root' })
export class AccountService {
    appUrl: string = "";

    constructor(private _http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
        this.appUrl = baseUrl;
    }

    getCustomerAccounts(id: string) {
        return this._http.get<AccountData[]>(this.appUrl + "api/Accounts/Customer/" + id);
    }
}