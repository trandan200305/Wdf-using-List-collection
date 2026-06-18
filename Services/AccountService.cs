using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountService iAccountService;
        public AccountService()
        {
            iAccountService = new AccountService();
        }
        public AccountMember GetAccountById(string accountID)
        {
            return iAccountService.GetAccountById(accountID);
        }
}
}
