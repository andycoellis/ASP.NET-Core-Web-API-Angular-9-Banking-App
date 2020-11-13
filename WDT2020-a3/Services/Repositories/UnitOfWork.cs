using WDT2020_a3.Services.DataManager.DBContexts;
using WDT2020_a3.Services.Repositories;

/*
 * UnitOfWork allows us to utilise a factory pattern in which all repositories used
 * have been wrapped in the DBContext, allowing us to utilise only one context
 * and monitor all changes in one movement
 */

namespace WDT2020_a3.Services.DataManager
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdminContext _context;

        public UnitOfWork(AdminContext context)
        {
            _context = context;
            Accounts = new AccountsRepository(_context);
            BillPays = new BillPaysRepository(_context);
            Customers = new CustomersRepository(_context);
            Logins = new LoginsRepository(_context);
            Transactions = new TransactionsRepository(_context);
        }

        public IAccountsRepository Accounts { get; private set; }
        public IBillPaysRepository BillPays { get; private set; }
        public ICustomersRepository Customers { get; private set; }
        public ILoginsRepository Logins { get; private set; }
        public ITransactionsRepository Transactions { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
