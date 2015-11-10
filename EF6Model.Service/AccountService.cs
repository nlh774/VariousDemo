using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EF6Model;

namespace EF6Model.Service
{
    public class AccountService
    {
        public List<AccountContract> Find()
        {
            using (EFTestContext context = new EFTestContext())
            {
                return context.Account.ToList();
            }
        }

        public AccountContract Find(long id)
        {
            using (EFTestContext context = new EFTestContext())
            {
                return context.Account.FirstOrDefault(t => t.AccountId == id);
            }
        }
    }
}
