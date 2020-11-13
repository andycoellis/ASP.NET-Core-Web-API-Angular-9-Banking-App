using WDT2020_a3.Models;
using WDT2020_a3.Services.DataManager.DBContexts;
using WDT2020_a3.Services.Repositories;

namespace WDT2020_a3.Services.DataManager
{
    public class AccountsRepository : Repository<Accounts>, IAccountsRepository
    {
        public AccountsRepository(AdminContext context) : base(context) { }

        public AdminContext AdminContext
        {
            get { return Context as AdminContext; }
        }
    }
}
