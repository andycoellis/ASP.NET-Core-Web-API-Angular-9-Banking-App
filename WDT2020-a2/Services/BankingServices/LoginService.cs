using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleHashing;
using WDT2020_a2.Data;
using WDT2020_a2.Exceptions;
using WDT2020_a2.Models;
using WDT2020_a2.Utilities;

namespace WDT2020_a2.Services.BankingServices
{
    public class LoginService
    {
        private const int ID_LENGTH = 8;

        private readonly NwabContext _context;


        public LoginService(NwabContext context)
        {
            _context = context;
        }

        ///<summary>Returns a newly generated Login with a given password</summary>
        public async Task CreateClient(string password, int customerID)
        {
            string id = "";

            do
            {
                id = UtilityFunctions.GenerateStringID(ID_LENGTH);

            } while (_context.Logins.FirstOrDefault(x => x.UserID.Equals(id)) != null);

            var login = new Login { UserID = id, Password = PBKDF2.Hash(password), CustomerID = customerID, ModifyDate = DateTime.UtcNow };

            try
            {
                _context.Add(login);

                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new CustomDatabaseException(nameof(Login), e.Message);
            }
        }

        public bool DoesClientExist(int id)
        {
            return _context.Logins.Any(e => Convert.ToInt32(e.UserID) == id);
        }

        public void PasswordAttemptsIncrement(string userID)
        {
            var login = _context.Logins
                .FirstOrDefault(x => Convert.ToInt32(x.UserID) == Convert.ToInt32(userID));

            login.PasswordAttempts++;

            try
            {
                _context.Update(login);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new CustomDatabaseException(nameof(Login), e.Message);
            }
        }

        public void LockAccount(string userID)
        {
            var login = _context.Logins
                .FirstOrDefault(x => Convert.ToInt32(x.UserID) == Convert.ToInt32(userID));

            login.BlockedAccount = true;
            login.ModifyDate = DateTime.Now;

            try
            {
                _context.Update(login);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                throw new CustomDatabaseException(nameof(Login), e.Message);
            }
        }

        public void PasswordAttemptsReset(string userID)
        {
            var login = _context.Logins
                .FirstOrDefault(x => Convert.ToInt32(x.UserID) == Convert.ToInt32(userID));

            login.PasswordAttempts = 0;

            try
            {
                _context.Update(login);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new CustomDatabaseException(nameof(Login), e.Message);
            }
        }

        public bool IsAccountLocked(string userID)
        {
            var login = _context.Logins
                .FirstOrDefault(x => Convert.ToInt32(x.UserID) == Convert.ToInt32(userID));

            try
            {
                return login.BlockedAccount;

            }
            catch (Exception e)
            {
                throw new CustomDatabaseException(nameof(Login), e.Message);
            }
        }
    }
}
