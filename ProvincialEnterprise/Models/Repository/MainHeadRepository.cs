using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class MainHeadRepository : Repository<MainHead>
    {
        public dynamic GetMainHeads()
        {
            var mainHeads = DbSet.Select(m => new
            {
                MainHeadId = m.MainHeadId,
                AccountTypeId = m.AccountTypeId,
                AccountTypeName = m.AccountType.Name,
                Name = m.Name,
                BranchId = m.BranchId,
                BranchName = m.Branch.Name
            }).ToList();

            return mainHeads;
        }

        public dynamic GetMainheadById(int id)
        {
            var mainHead = DbSet.Where(m => m.MainHeadId == id).Select(h => new
            {
                MainHeadId = h.MainHeadId,
                AccountTypeId = h.AccountTypeId,
                AccountTypeName = h.AccountType.Name,
                Name = h.Name,
                BranchId = h.BranchId
            }).FirstOrDefault();

            return mainHead;
        }

        public dynamic GetMainHeadsByBranch(int branchId)
        {
            var accounts = DbSet.Where(x => x.BranchId == branchId).Select(a => new
            {
                a.MainHeadId,
                a.Name
            }).ToList();

            return accounts;
        }


        public MainHead GetById(int id)
        {
            MainHead mainHead = DbSet.Where(m => m.MainHeadId == id).FirstOrDefault();
            return mainHead;
        }
        public bool GetDuplicate(int accountTypeId,string name)
        {
            var mainhead = DbSet.Where(c => c.Name.ToLower() == name.ToLower() && c.AccountTypeId == accountTypeId).FirstOrDefault();
            return (mainhead != null) ? true : false;
        }
    }
}