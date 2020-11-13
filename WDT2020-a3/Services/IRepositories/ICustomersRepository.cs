using WDT2020_a3.Models;

namespace WDT2020_a3.Services.Repositories
{
    public interface ICustomersRepository : IRepository<Customers>
    {
        public void NewCustomer(Customers customer);
        public void EditCustomer(Customers customer);
    }
}
