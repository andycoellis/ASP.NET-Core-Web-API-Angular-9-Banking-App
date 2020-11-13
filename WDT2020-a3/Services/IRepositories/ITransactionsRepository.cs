using System.Collections.Generic;
using WDT2020_a3.Models;

namespace WDT2020_a3.Services.Repositories
{
    public interface ITransactionsRepository : IRepository<Transactions>
    {
        IEnumerable<Transactions> GetAllTransactionsOrderByModifyDate();
        IEnumerable<Transactions> GetAllAccountTransactionsOrderByModifyDate(int id);
        IDictionary<string, int> GetTransactionTypesWithCount(IEnumerable<Transactions> transactions);
        IDictionary<string, int> GetPastWeekTransactionsCount(IEnumerable<Transactions> transactions);
        IDictionary<string, double> GetCashFlow(IEnumerable<Transactions> transactions);
    }
}
