using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WDT2020_a3.Models;
using WDT2020_a3.Services;
using WDT2020_a3.Services.DataManager;
using WDT2020_a3.Services.DataManager.DBContexts;

namespace WDT2020_a3.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomersController(AdminContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IEnumerable<Customers> Get()
        {
            return unitOfWork.Customers.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Customers GetCustomer(int id)
        {
            return unitOfWork.Customers.Get(id);
        }

        [HttpPut]
        [Route("Edit")]
        public void EditCustomer([FromBody] Customers customer)
        {
            unitOfWork.Customers.EditCustomer(customer);
            unitOfWork.Complete();
        }

        [HttpPost]
        [Route("New")]
        public void NewCustomer([FromBody] Customers customer)
        {
            unitOfWork.Customers.NewCustomer(customer);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public void DeleteCustomer(int id)
        {
            unitOfWork.Customers.Remove(unitOfWork.Customers.Get(id));
        }
    }
}
