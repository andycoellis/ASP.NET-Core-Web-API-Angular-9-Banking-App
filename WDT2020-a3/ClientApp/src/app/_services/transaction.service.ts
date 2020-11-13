import { Injectable, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";

export interface TransactionData {
    transactionId: number;
    transactionType: string;
    accountNumber: number;
    destAccount: number;
    amount: number;
    comment: string;
    modifyDate: Date;
}

@Injectable({ providedIn: 'root' })
export class TransactionService {
    appUrl: string = "";

    constructor(private _http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
        this.appUrl = baseUrl;
    }

    getAccountTransactions(id: string) {
        return this._http.get<TransactionData[]>(this.appUrl + "api/Transactions/Account/" + id)
    }

    getAllTransactions() {
        return this._http.get<TransactionData[]>(this.appUrl + "api/Transactions");
    }

    getTypesCountAll() {
        return this._http.get<any>(this.appUrl + "api/Transactions/TypeCount");
    }

    getTypesCount(id) {
        return this._http.get<any>(this.appUrl + "api/Transactions/TypeCount/" + id);
    }

    getPastWeekCountAll() {
        return this._http.get<any>(this.appUrl + "api/Transactions/PastWeek");
    }

    getPastWeekCount(id) {
        return this._http.get<any>(this.appUrl + "api/Transactions/PastWeek/" + id);
    }

    getCashFlowAll() {
        return this._http.get<any>(this.appUrl + "api/Transactions/CashFlow");
    }

    getCashFlow(id) {
        return this._http.get<any>(this.appUrl + "api/Transactions/CashFlow/" + id);
    }
}