import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { TransactionService, TransactionData } from "../../_services";

@Component({
    selector: "app-statement",
    templateUrl: "./statement.component.html"
})
export class StatementComponent {
    originalList: TransactionData[];
    transactionList: TransactionData[];
    accountNumber: string;

    constructor(private _transactionService: TransactionService, private route: ActivatedRoute) {
        if (this.route.snapshot.paramMap.get('id')) {
            this.accountNumber = this.route.snapshot.paramMap.get('id');
            this.getAccountTransactions(this.accountNumber);
        } else {
            this.getAllTransactions();
        }
    }

    getAllTransactions() {
        this._transactionService.getAllTransactions().subscribe(data => this.transactionList = data);
    }

    getAccountTransactions(id: string) {
        this._transactionService.getAccountTransactions(id).subscribe(data => this.transactionList = data);
    }

    filter() {
        // used to keep a copy of the original list
        if (!this.originalList)
            this.originalList = this.transactionList;

        // new list of transactions to add filtered results to
        let filtered: TransactionData[] = [];

        this.originalList.forEach(t => {
            // get dates from page
            let startDate = (<HTMLInputElement>document.getElementById("startDate")).valueAsDate;
            let endDate = (<HTMLInputElement>document.getElementById("endDate")).valueAsDate;

            // converting transaction date toString to facilitate comparison
            let transactionDate = Date.parse(t.modifyDate.toString());

            // create serialized string of transaction data (not including date)
            let transaction = new String(t.transactionId + t.transactionType + t.accountNumber + t.destAccount + t.amount + t.comment).toLowerCase();

            // get value of text field for searching, convert to regex
            let search = (<HTMLInputElement>document.getElementById("search")).value;
            let filterRegex = new RegExp(((search).toLowerCase()),"g");

            // check if transaction date in range
            if (transactionDate.valueOf() > startDate.valueOf() && transactionDate.valueOf() < endDate.valueOf()) {
                // check if search term in transaction data
                if (transaction.search(filterRegex) != -1) {
                    filtered.push(t);
                }
            }
        });
        // update transaction list with filtered list to re-render page
        this.transactionList = filtered;
    }
}
