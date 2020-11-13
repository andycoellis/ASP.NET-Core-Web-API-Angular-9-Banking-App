using System;
using System.Collections.Generic;
using System.Linq;
using WDT2020_a3.Models;
using WDT2020_a3.Services.DataManager.DBContexts;
using WDT2020_a3.Services.Repositories;

namespace WDT2020_a3.Services.DataManager
{
    public class BillPaysRepository : Repository<BillPays>, IBillPaysRepository
    {
        public BillPaysRepository(AdminContext context) : base(context) { }

        public IEnumerable<BillPays> GetCustomerBills(int customerId)
        {
            var custAccts = from c in AdminContext.Customers
                            join a in AdminContext.Accounts
                            on c.CustomerId equals a.CustomerId
                            where c.CustomerId == customerId
                            select a;

            var bills = from b in AdminContext.BillPays
                        join c in custAccts
                        on b.AccountNumber equals c.AccountNumber
                        select b;

            return bills.ToList();
        }

        public void ToggleAccountStatus(int billPayId)
        {
            var bill = Get(billPayId);

            bill.BlockedBillPay = !bill.BlockedBillPay;
            bill.ModifyDate = DateTime.Now;
        }

        public AdminContext AdminContext
        {
            get { return Context as AdminContext; }
        }
    }
}