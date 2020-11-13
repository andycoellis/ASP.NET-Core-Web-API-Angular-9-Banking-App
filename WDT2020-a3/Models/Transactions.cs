using System;

namespace WDT2020_a3.Models
{
    public partial class Transactions
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public int AccountNumber { get; set; }
        public int DestAccount { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual Accounts AccountNumberNavigation { get; set; }
    }
}
