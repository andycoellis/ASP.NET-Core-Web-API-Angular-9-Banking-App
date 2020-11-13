import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

export interface BillPaysData {

  billPayId: number;
  accountNumber: number;
  payeeId: number;
  amount: number;
  scheduleDate: Date;
  period: string;
  modifyDate: Date;
  blockedBillPay: boolean;
}

@Injectable({ providedIn: 'root' })
export class BillPayService {
  myAppUrl: string = "";

  constructor(private _http: HttpClient, @Inject("BASE_URL") baseUrl: string)
  {
    this.myAppUrl = baseUrl;
  }

  getBills()
  {
    return this._http.get<BillPaysData[]>(this.myAppUrl + "api/Billpays/Index");
  }

  getCustBills(id) {
    return this._http.get<BillPaysData[]>(this.myAppUrl + "api/BillPays/Bills/" + id);
  }

  updateBillPayStatus(id){
    return this._http.put<any>(this.myAppUrl + "api/Billpays/Block/" + id, null);
  }
}