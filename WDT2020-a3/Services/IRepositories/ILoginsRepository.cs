using WDT2020_a3.Models;

namespace WDT2020_a3.Services.Repositories
{
    public interface ILoginsRepository : IRepository<Logins>
    {
        void ToggleAccountStatus(int customerId);
    }
}
