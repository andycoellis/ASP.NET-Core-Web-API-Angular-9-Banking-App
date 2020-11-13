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
    public class LoginsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public LoginsController(AdminContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("Accounts")]
        public IEnumerable<Logins> GetAll()
        {
            return unitOfWork.Logins.GetAll();
        }

        [HttpGet]
        [Route("Login/{id}")]
        public Logins Get(int id)
        {
            return unitOfWork.Logins.SingleOrDefault(x => x.CustomerId == id);
        }

        [HttpGet]
        [Route("Locked")]
        public IEnumerable<Logins> GetLocked()
        {
            return unitOfWork.Logins.Find(x => x.BlockedAccount == true);
        }

        [HttpPut("Lock/{id}")]
        public void Update(int id)
        {
            unitOfWork.Logins.ToggleAccountStatus(id);
            unitOfWork.Complete();

        }
    }
}
