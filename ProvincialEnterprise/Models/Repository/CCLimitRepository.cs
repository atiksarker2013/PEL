using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class CCLimitRepository : Repository<CCLimit>
    {
        // PELDBEntities pel = new PELDBEntities();
        //public dynamic GetCCLimits()
        //{
        //    var cclimits = DbSet.OrderBy(c => c.Id).Select(c => new
        //    {
        //        Id = c.Id,
        //        BankId = c.BankId,
        //        BankName = c.Bank.BankName,
        //        LimitAmount = c.LimitAmount,
        //        EntryDate = c.EntryDate.ToString(),
        //        BranchId = c.BranchId,
        //        BranchName = c.Branch.Name,
        //        CompanyName=c.Branch.Company.Name,
        //    }).ToList();
        //    return cclimits;
        //}
        public dynamic GetCCLimitByBranch(int branchId)
        {
            var cclimits = DbSet.Where(c => c.BranchId == branchId).Select(c => new
            {
                Id = c.Id,
                BankId = c.BankId,
                BankName = c.Bank.BankName,
                LimitAmount = c.LimitAmount,
                EntryDate = c.EntryDate,
                BranchId = c.BranchId,
                BranchName = c.Branch.Name,
            }).ToList();

            return cclimits;
        }


        public bool GetDuplicateCCLimit(int barnchId, int bankId)
        {
            //var cclimit = DbSet.Where(c => c.Id == id && c.BankId == bankId).FirstOrDefault();
            //return (cclimit != null) ? true : false;

            var cclimits = DbSet.OrderBy(c => c.Id).ToList();
            foreach (CCLimit c in cclimits)
            {
                if (c.BranchId == barnchId && c.BankId == bankId)
                {
                    return true;
                }
            }
            return false;
        }

        public dynamic GetCCLimitById(int id)
        {
            var cclimit = DbSet.Where(c => c.Id == id).Select(c => new
            {
                Id = c.Id,
                BankId = c.BankId,
                BankName = c.Bank.BankName,
                LimitAmount = c.LimitAmount,
                EntryDate = c.EntryDate,
                BranchId = c.BranchId,
                BranchName = c.Branch.Name,
                CompanyName = c.Branch.Company.Name,
            }).FirstOrDefault();

            return cclimit;

        }
      
    }
}