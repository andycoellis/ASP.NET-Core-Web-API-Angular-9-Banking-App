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
    public class AccountsController
    {
        private readonly IUnitOfWork unitOfWork;

        public AccountsController(AdminContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("Customer/{id}")]
        public IEnumerable<Accounts> GetCustomerAccounts(int id)
        {
            return unitOfWork.Accounts.Find(x => x.CustomerId == id);
        } 

    }
}
