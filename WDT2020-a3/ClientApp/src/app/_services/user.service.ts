import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";


export interface UserData {
  userId: string;
  customerId: number;
  password: string;
  modifyDate: Date;
  passwordAttempts: number;
  blockedAccount: boolean;

}

@Injectable({ providedIn: 'root' })
export class UserService {
  appUrl: string = "";

  constructor(private _http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.appUrl = baseUrl;
  }

  getUsers() {
    return this._http.get<UserData[]>(this.appUrl + "api/Logins/Accounts");
  }

  getLogin(custId: number) {
    return this._http.get<UserData>(this.appUrl + "api/Logins/Login/" + custId);
  }

  getLockedUsers() {
    return this._http.get<UserData[]>(this.appUrl + "api/Logins/Locked");
  }

  lock(id: number) {
    return this._http.put<UserData>(this.appUrl + "api/Logins/Lock/" + id, null);
  }
}