import { Component } from "@angular/core";
import { CustomerService, CustomerData } from "../../_services";

@Component({ templateUrl: "customers.component.html" })
export class CustomersComponent {
    customerList: CustomerData[];

    constructor(private _customerService: CustomerService) {
        this.getCustomers();
    }
    
    getCustomers() {
        this._customerService.getCustomers().subscribe(data => this.customerList = data);
    }

    // function adapted from Week 10 Code Example
    deleteCustomer(customerId) {
        if(confirm("Are you sure you want to delete customer " + customerId)) {
            this._customerService.deleteCustomer(customerId).subscribe((data) => {
                this.getCustomers()
            });
        }
    }
}