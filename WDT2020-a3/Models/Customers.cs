using System;
using System.Collections.Generic;

namespace WDT2020_a3.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Accounts = new HashSet<Accounts>();
            Logins = new HashSet<Logins>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Tfn { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Logins> Logins { get; set; }
    }
}
