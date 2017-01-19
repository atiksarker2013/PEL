using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class BankRepository : Repository<Bank>
    {
        public dynamic GetBanks()
        {
            var banks = DbSet.Select(c => new
            {
                BankId = c.BankId,
                BankName = c.BankName,
                Branch = c.Branch,
                AccountNo = c.AccountNo,
                Opening = c.Opening,
                BranchId = c.BranchId,
                Branchname = c.Branch1.Name
            }).ToList();

            return banks;
        }

        public dynamic GetBankById(int id)
        {
            var bank = DbSet.Where(a => a.BankId == id).Select(c => new
            {
                BankId = c.BankId,
                BankName = c.BankName,
                Branch = c.Branch,
                AccountNo = c.AccountNo,
                Opening = c.Opening,
                BranchId = c.BranchId
            }).FirstOrDefault();

            return bank;
        }
        public bool GetDuplicate(int branchId,string name)
        {
            var bank = DbSet.Where(c => c.BankName.ToLower() == name.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (bank != null) ? true : false;
        }

        public dynamic GetBankByAccoutId(int id)
        {
            var bank = DbSet.Where(c =>  c.AccountId == id).FirstOrDefault();
            return bank;
        }
    }
}