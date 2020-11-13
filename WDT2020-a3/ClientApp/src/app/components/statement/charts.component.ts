import { Component, OnInit } from "@angular/core";
import { Chart } from "chart.js";
import { TransactionService } from "../../_services";
import { ActivatedRoute } from "@angular/router";

@Component({
    selector: "app-statement-charts",
    templateUrl: "./charts.component.html"
})
export class ChartsComponent implements OnInit{
    accountNumber: string;
    typesCount: any;
    pastWeekCount: any;
    cashFlow: any;

    constructor(private _transactionService: TransactionService, private route: ActivatedRoute) {
        if (this.route.snapshot.paramMap.get('id')) {
            this.accountNumber = this.route.snapshot.paramMap.get('id');
        }
    }

    ngOnInit() {
        // generate charts here to ensure accountNumber is set
        this.generateCharts();
    }

    generateCharts() {
        // chains through getting data, updating data, and generating chart
        this.getTypesCount();
        this.getPastWeekCount();
        this.getCashFlow();
    }

    getTypesCount() {
        if (this.accountNumber) {
            this._transactionService.getTypesCount(this.accountNumber).subscribe(data => this.updateTypesCount(data));
        } else {
            this._transactionService.getTypesCountAll().subscribe(data => this.updateTypesCount(data));
        }
    }

    updateTypesCount(data) {
        this.typesCount = data;
        let tcLabels: string[] = [];
        let tcData: number[] = [];

        for (let key in this.typesCount) {
            let value = this.typesCount[key];

            tcLabels.push(key);
            tcData.push(value);
        }
        this.generateTypesCountChart(tcLabels, tcData);
    }

    generateTypesCountChart(labels: string[], data: number[]) {
        var canvas = document.getElementById("typesCountChart");

        new Chart(canvas, {
            type: "pie",
            data: {
                labels: labels,
                datasets: [{
                    label: "Transaction Types",
                    data: data,
                    backgroundColor: ["green", "red", "yellow", "blue"],
                    borderColour: "rgba(0, 0, 0, 1)",
                    borderWidth: 1
                }]
            }
        })
    }

    getPastWeekCount() {
        if (this.accountNumber) {
            this._transactionService.getPastWeekCount(this.accountNumber).subscribe(data => this.updatePastWeekCount(data));
        } else {
            this._transactionService.getPastWeekCountAll().subscribe(data => this.updatePastWeekCount(data));
        }
    }

    updatePastWeekCount(data) {
        this.pastWeekCount = data;
        let pwLabels: string[] = [];
        let pwData: number[] = [];

        for (let key in this.pastWeekCount) {
            let value = this.pastWeekCount[key];

            pwLabels.push(key);
            pwData.push(value);
        }
        this.generatePastWeekCountChart(pwLabels, pwData);
    }

    generatePastWeekCountChart(labels, data) {
        var canvas = document.getElementById("pastWeekCountChart");

        new Chart(canvas, {
            type: "bar",
            data: {
                labels: labels,
                datasets: [{
                    label: "Past Week of Transactions",
                    data: data,
                    backgroundColor: "rgba(200, 100, 100, 1)",
                    borderColour: "rgba(0, 0, 0, 1)",
                    borderWidth: 1
                }]
            },
            options: {
                legend: {display: false},
            }
        })
    }

    getCashFlow() {
        if (this.accountNumber) {
            this._transactionService.getCashFlow(this.accountNumber).subscribe(data => this.updateCashFlow(data));
        } else {
            this._transactionService.getCashFlowAll().subscribe(data => this.updateCashFlow(data));
        }
    }

    updateCashFlow(data) {
        this.cashFlow = data;
        let cfLabels: string[] = [];
        let cfData: number[] = [];

        for (let key in this.cashFlow) {
            let value = this.cashFlow[key];

            cfLabels.push(key);
            cfData.push(value);
        }
        this.generateCashFlowChart(cfLabels, cfData);
    }

    generateCashFlowChart(labels, data) {
        var canvas = document.getElementById("cashFlowChart");

        new Chart(canvas, {
            type: "bar",
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    backgroundColor: ["green", "red"],
                    borderColour: "rgba(0, 0, 0, 1)",
                    borderWidth: 1
                }]
            },
            options: {
                legend: {display: false},
            }
        })
    }
}