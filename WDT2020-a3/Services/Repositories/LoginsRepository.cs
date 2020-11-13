using System;
using WDT2020_a3.Models;
using WDT2020_a3.Services.DataManager.DBContexts;
using WDT2020_a3.Services.Repositories;

namespace WDT2020_a3.Services.DataManager
{
    public class LoginsRepository : Repository<Logins>, ILoginsRepository
    {
        public LoginsRepository(AdminContext context) : base(context) { }

        public void ToggleAccountStatus(int customerId)
        {
            var login = SingleOrDefault(x => x.CustomerId == customerId);

            login.BlockedAccount = !login.BlockedAccount;
            login.PasswordAttempts = 0;
            login.ModifyDate = DateTime.Now;
        }
        
        public AdminContext AdminContext
        {
            get { return Context as AdminContext; }
        }
    }
}
