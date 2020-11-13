using System;
using System.Collections.Generic;

namespace WDT2020_a3.Models
{
    public partial class Payees
    {
        public Payees()
        {
            BillPays = new HashSet<BillPays>();
        }

        public int PayeeId { get; set; }
        public string PayeeName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<BillPays> BillPays { get; set; }
    }
}
