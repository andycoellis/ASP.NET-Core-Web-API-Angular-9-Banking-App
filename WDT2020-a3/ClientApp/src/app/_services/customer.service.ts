import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

export interface CustomerData {
    customerId: number;
    customerName: string;
    tfn: string;
    address: string;
    city: string;
    state: string;
    postCode: string;
    phone: string;
}

@Injectable({ providedIn: 'root' })
export class CustomerService {
    appUrl: string = "";

    constructor(private _http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
        this.appUrl = baseUrl;
    }

    getCustomers() {
        return this._http.get<CustomerData[]>(this.appUrl + "api/Customers");
    }

    getCustomer(id: string) {
        return this._http.get<CustomerData>(this.appUrl + "api/Customers/" + id);
    }

    editCustomer(customer) {
        return this._http.put(this.appUrl + "api/Customers/Edit", customer);
    }

    newCustomer(customer) {
        return this._http.post(this.appUrl + "api/Customers/New", customer);
    }

    deleteCustomer(customerId) {
        return this._http.delete(this.appUrl + "api/Customers/Delete/" + customerId);
    }
}