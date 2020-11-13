import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { BillPaysData, BillPayService } from "../../_services";

@Component({
  selector: "app-fetch-billpays",
  templateUrl: "./fetch-billpays-component.html"
})

export class FetchBillPaysComponent {
  billList: BillPaysData[];
  customerId: string;

  constructor(private _billPayService: BillPayService, private _route: ActivatedRoute) {
    if (this._route.snapshot.paramMap.get('id')) {
      this.customerId = this._route.snapshot.paramMap.get('id');
      this.getCustBills(this.customerId);
    } else {
      this.getBills();
    }
  }

  getBills() {
    this._billPayService.getBills().subscribe(data => this.billList = data);
  }

  getCustBills(id) {
    this._billPayService.getCustBills(id).subscribe(data => this.billList = data);
  }

  updateStatus(id){
    if (this.customerId) {
      this._billPayService.updateBillPayStatus(id).subscribe((data) => {this.getCustBills(this.customerId)});
    } else {
      this._billPayService.updateBillPayStatus(id).subscribe((data) => {this.getBills()});
    }
  }
}