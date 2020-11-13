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
    public class TransactionsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public TransactionsController(AdminContext context)
        {
            unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IEnumerable<Transactions> Get()
        {
            return unitOfWork.Transactions.GetAllTransactionsOrderByModifyDate();
        }

        [HttpGet]
        [Route("Account/{id}")]
        public IEnumerable<Transactions> GetAccountTransactions(int id)
        {
            return unitOfWork.Transactions.GetAllAccountTransactionsOrderByModifyDate(id);
        }

        [HttpGet]
        [Route("TypeCount")]
        public IDictionary<string, int> GetTypesCount()
        {
            return unitOfWork.Transactions.GetTransactionTypesWithCount(Get());
        }
        [HttpGet]
        [Route("TypeCount/{id}")]
        public IDictionary<string, int> GetTypesCount(int id)
        {
            return unitOfWork.Transactions.GetTransactionTypesWithCount(GetAccountTransactions(id));
        }

        [HttpGet]
        [Route("PastWeek")]
        public IDictionary<string, int> GetPastWeekCount()
        {
            return unitOfWork.Transactions.GetPastWeekTransactionsCount(Get());
        }

        [HttpGet]
        [Route("PastWeek/{id}")]
        public IDictionary<string, int> GetPastWeek(int id)
        {
            return unitOfWork.Transactions.GetPastWeekTransactionsCount(GetAccountTransactions(id));
        }

        [HttpGet]
        [Route("CashFlow")]
        public IDictionary<string, double> GetCashFlow()
        {
            return unitOfWork.Transactions.GetCashFlow(Get());
        }

        [HttpGet]
        [Route("CashFlow/{id}")]
        public IDictionary<string, double> GetCashFlow(int id)
        {
            return unitOfWork.Transactions.GetCashFlow(GetAccountTransactions(id));
        }
    }
}
