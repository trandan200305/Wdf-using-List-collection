using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    internal class AccountRepository : IAccountRepository
    {
        public AccountMember GetAccountByID(string accountID) => AccountDAO.GetAccountByID(accountID);
    }
}
