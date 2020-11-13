import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router, ActivatedRoute } from "@angular/router";
import { CustomerService } from "../../_services";

@Component({
    selector: "app.customers.edit",
    templateUrl: "./edit.component.html"
})
export class EditCustomerComponent implements OnInit {
    customerForm: FormGroup;
    title: string = "New Customer"
    // hardcoded list of states for form
    stateList: string[] = ["VIC", "QLD", "SA", "ACT", "NSW", "WA", "TAS", "NT"];

    constructor(private _formBuilder: FormBuilder, private _customerService: CustomerService, private route: ActivatedRoute, private _router: Router) {
        // formGroup for validation
        this.customerForm = this._formBuilder.group({
            customerId: 0,
            customerName: ["", [Validators.required, Validators.maxLength(50)]],
            tfn: ["", [Validators.minLength(9), Validators.maxLength(9)]],
            address: ["", [Validators.maxLength(50)]],
            city: ["", [Validators.maxLength(40)]],
            state: [""],
            postCode: ["", [Validators.maxLength(4), Validators.minLength(4)]],
            phone: ["", [Validators.minLength(17), Validators.maxLength(17)]],
            accounts: [],
            logins: []
        });
    }

    ngOnInit() {
        // setup editing of customer if id set as parameter
        if (this.route.snapshot.paramMap.get('id')) {
            this.title = "Edit Customer";
            this.getCustomer(this.route.snapshot.paramMap.get('id'));
        }
    }

    getCustomer(id: string) {
        this._customerService.getCustomer(id).subscribe(resp => this.customerForm.setValue(resp));
    }

    processCustomer() {
        // return to form if validation fails
        if (this.customerForm.invalid) {
            return;
        }

        // pass to correct method if new or edit        
        if (this.title == "New Customer") {
            console.log(this.customerForm.value);
            this._customerService.newCustomer(this.customerForm.value).subscribe((data) => {
                this._router.navigate(["/customers"]);
              });

        } else if (this.title == "Edit Customer") {
            this._customerService.editCustomer(this.customerForm.value).subscribe((data) => {
                this._router.navigate(["/customers"]);
              });
        }
    }

    // getters for form elements, required for validation
    get customerName() {
        return this.customerForm.get("customerName");
    }
    get tfn() {
        return this.customerForm.get("tfn");
    }
    get address() {
        return this.customerForm.get("address");
    }
    get city() {
        return this.customerForm.get("city");
    }
    get postCode() {
        return this.customerForm.get("postCode");
    }
    get phone() {
        return this.customerForm.get("phone");
    }
}