using System.Collections.Generic;
using WDT2020_a3.Models;

namespace WDT2020_a3.Services.Repositories
{
    public interface IBillPaysRepository : IRepository<BillPays>
    {
        IEnumerable<BillPays> GetCustomerBills(int customerId);
        void ToggleAccountStatus(int billPayId);
    }
}
