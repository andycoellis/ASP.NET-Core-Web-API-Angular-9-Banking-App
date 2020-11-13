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
    public class BillPaysController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BillPaysController(AdminContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        [Route("Index")]
        public IEnumerable<BillPays> Get()
        {
            return unitOfWork.BillPays.GetAll();
        }

        [HttpGet]
        [Route("Bill/{id}")]
        public BillPays GetBill(int id)
        {
            return unitOfWork.BillPays.Get(id);
        }

        [HttpGet]
        [Route("Bills/{id}")]
        public IEnumerable<BillPays> GetCustBills(int id)
        {
            return unitOfWork.BillPays.GetCustomerBills(id);
        }

        [HttpPut]
        [Route("Block/{id}")]
        public void UpdateBlockedBill(int id)
        {
            unitOfWork.BillPays.ToggleAccountStatus(id);
            unitOfWork.Complete();
        }
    }
}
