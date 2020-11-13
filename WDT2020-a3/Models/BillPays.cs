using System;

namespace WDT2020_a3.Models
{
    public partial class BillPays
    {
        public int BillPayId { get; set; }
        public int AccountNumber { get; set; }
        public int PayeeId { get; set; }
        public double Amount { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Period { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool BlockedBillPay { get; set; }

        public virtual Accounts AccountNumberNavigation { get; set; }
        public virtual Payees Payee { get; set; }
    }
}
