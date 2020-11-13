using System;
using WDT2020_a3.Services.Repositories;

namespace WDT2020_a3.Services
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountsRepository Accounts { get; }
        IBillPaysRepository BillPays { get; }
        ICustomersRepository Customers { get; }
        ILoginsRepository Logins { get; }
        ITransactionsRepository Transactions { get; }
        int Complete();
    }
}
