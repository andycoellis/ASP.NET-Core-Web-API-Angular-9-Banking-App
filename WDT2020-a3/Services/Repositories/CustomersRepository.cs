using System;
using Microsoft.EntityFrameworkCore;
using WDT2020_a3.Models;
using WDT2020_a3.Services.DataManager.DBContexts;
using WDT2020_a3.Services.Repositories;

namespace WDT2020_a3.Services.DataManager
{
    public class CustomersRepository : Repository<Customers>, ICustomersRepository
    {
        public CustomersRepository(AdminContext context) : base(context) { }

        public void NewCustomer(Customers customer)
        {
            customer.CustomerId = GetNewCustomerID();

            Add(customer);
        }

        private int GetNewCustomerID()
        {
            int uniqueID;
            do
            {
                uniqueID = new Random().Next(1000, 9999);
            } while (Get(uniqueID) != null);
            return uniqueID;
        }

        public void EditCustomer(Customers customer)
        {
            AdminContext.Entry(customer).State = EntityState.Modified;
        }

        public AdminContext AdminContext
        {
            get { return Context as AdminContext; }
        }
    }
}
