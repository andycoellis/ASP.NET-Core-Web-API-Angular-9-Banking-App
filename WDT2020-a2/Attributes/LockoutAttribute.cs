using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WDT2020_a2.Data;
using WDT2020_a2.Models;

namespace WDT2020_a2.Attributes
{
    public class LockoutAttribute : ActionFilterAttribute
    {
        private readonly NwabContext _context;

        public LockoutAttribute(NwabContext context)
        {
            _context = context;
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userID = filterContext.ActionArguments["userID"];

            if(userID != null)
            {
                var login = _context.Logins.FirstOrDefault(x => x.UserID.Equals((string)userID));

                if (login.BlockedAccount && login.ModifyDate.AddSeconds(60) < DateTime.Now)
                {
                    login.BlockedAccount = false;
                    login.PasswordAttempts = 0;
                    login.ModifyDate = DateTime.Now;

                    _context.Update(login);
                    _context.SaveChanges();
                }
            }
        }
    }
}
