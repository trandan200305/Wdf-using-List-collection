using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
namespace Repositories
{
    public class IAccountRepository
    {
        AccountMenber GetAccountById(string accountID);
    }
}
