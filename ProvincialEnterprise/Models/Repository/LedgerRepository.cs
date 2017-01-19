using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class LedgerRepository : Repository<Account>
    {
        public dynamic GetAccounts()
        {
            var accounts = DbSet.Select(a => new
            {
                AccountId = a.AccountId,
                AccountName = a.AccountName,
                MainHeadId = a.MainHeadId,
                MainAccount = a.MainHead.Name,
                BranchId = a.BranchId,
                BranchName = a.Branch.Name
            }).ToList();

            return accounts;
        }

       
        public dynamic GetPurchaseAccounts()
        {
            var accounts = DbSet.Where(x=> x.MainHeadId == 4).Select(a => new
            {
                AccountId = a.AccountId,
                Name = a.AccountName,
                MainHeadId = a.MainHeadId,
                MainAccount = a.MainHead.Name,
                BranchId = a.BranchId,
                BranchName = a.Branch.Name
            }).ToList();

            return accounts;
        }

        public dynamic GetAccountById(int id)
        {
            var account = DbSet.Where(c => c.AccountId == id).Select(a => new
            {
                AccountId = a.AccountId,
                AccountName = a.AccountName,
                //Name = a.AccountName,
                //MainHeadId = a.MainHeadId,
                BranchId = a.BranchId
            }).FirstOrDefault();

            return account;
        }


        public dynamic GetAcount()
        {
            var account = DbSet.Where(c => c.AccountId == 9).Select(x => new
            {
                x.AccountId,
                x.AccountName
            }).FirstOrDefault();
            return account;
        }
        public bool GetDuplicate(int mainHeadId,string name)
        {
            var ledger = DbSet.Where(c => c.AccountName.ToLower() == name.ToLower() && c.MainHeadId == mainHeadId).FirstOrDefault();
            return (ledger != null) ? true : false;
        }

        public Account GetById(int id)
        {
            return DbSet.Where(c => c.AccountId == id).FirstOrDefault();
        }
    }
}