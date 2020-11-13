using System;
using System.Collections.Generic;
using System.Linq;
using WDT2020_a3.Models;
using WDT2020_a3.Services.DataManager.DBContexts;
using WDT2020_a3.Services.Repositories;

namespace WDT2020_a3.Services.DataManager
{
    public class TransactionsRepository : Repository<Transactions>, ITransactionsRepository
    {
        public TransactionsRepository(AdminContext context) : base(context) { }


        public IEnumerable<Transactions> GetAllTransactionsOrderByModifyDate()
        {
            return AdminContext.Transactions.OrderBy(x => x.ModifyDate).ToList();
        }

        public IEnumerable<Transactions> GetAllAccountTransactionsOrderByModifyDate(int id)
        {
            return Find(x => x.AccountNumber == id).OrderBy(x => x.ModifyDate);
        }

        public IDictionary<string, double> GetCashFlow(IEnumerable<Transactions> transactions)
        {
            var result = new Dictionary<string, double>()
            {
                {"Credits", 0},
                {"Debits", 0}
            };

            foreach (Transactions t in transactions)
            {
                if (t.TransactionType == "D")
                {
                    result["Credits"] += t.Amount;
                }
                else
                {
                    result["Debits"] += t.Amount;
                }
            }

            return result;
        }

        public IDictionary<string, int> GetPastWeekTransactionsCount(IEnumerable<Transactions> transactions)
        {
            // get current time
            var now = DateTime.Now;
            var result = new Dictionary<string, int>();

            // i initialized 6 to go back to start of week
            for (int i = 6; i >= 0; i--)
            {
                // update current day based on loop
                var day = now.AddDays(-i);
                int count = 0;

                foreach (Transactions t in transactions)
                {
                    if (t.ModifyDate.Date == day.Date)
                        count++;
                }
                // add day and transaction count to dictionary
                result.Add(day.DayOfWeek.ToString(), count);
            }

            return result;
        }

        public IDictionary<string, int> GetTransactionTypesWithCount(IEnumerable<Transactions> transactions)
        {
            var result = new Dictionary<string, int>()
            {
                {"Deposits", 0 },
                {"Withdrawals", 0 },
                {"Transfers", 0 },
                {"Bill Pays", 0 }
            };

            foreach (Transactions t in transactions)
            {
                switch (t.TransactionType)
                {
                    case "D":
                        result["Deposits"]++;
                        break;
                    case "W":
                        result["Withdrawals"]++;
                        break;
                    case "T":
                        result["Transfers"]++;
                        break;
                    case "B":
                        result["Bill Pays"]++;
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        public AdminContext AdminContext
        {
            get { return Context as AdminContext; }
        }
    }
}
