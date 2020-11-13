using System;
using System.Collections.Generic;

namespace WDT2020_a3.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            BillPays = new HashSet<BillPays>();
            Transactions = new HashSet<Transactions>();
        }

        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public int CustomerId { get; set; }
        public double Balance { get; set; }
        public DateTime ModifyDate { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual ICollection<BillPays> BillPays { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
