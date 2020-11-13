using System;

namespace WDT2020_a3.Models
{
    public partial class Logins
    {
        public string UserId { get; set; }
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public DateTime ModifyDate { get; set; }
        public int PasswordAttempts { get; set; }
        public bool BlockedAccount { get; set; }

        public virtual Customers Customer { get; set; }
    }
}
