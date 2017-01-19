using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class BranchRepository : Repository<Branch>
    {
        public dynamic GetBranches()
        {
            var branches = DbSet.Select(b => new
            {
                BranchId = b.BranchId,
                Name = b.Name,
                Address = b.Address,
                Contact = b.Contact,
                Web = b.Web,
                Email = b.Email,
                CompanyId = b.CompanyId,
                CompanyName = b.Company.Name
            }).ToList();

            return branches;
        }

        public dynamic GetBranchesByCompany(int companyId)
        {
            var branches = DbSet.Where(x=> x.CompanyId == companyId).Select(b => new
            {
                BranchId = b.BranchId,
                Name = b.Name,
                Address = b.Address,
                Contact = b.Contact,
                Web = b.Web,
                Email = b.Email,
                CompanyId = b.CompanyId,
                CompanyName = b.Company.Name
            }).ToList();

            return branches;
        }
        public dynamic GetBrancheById(int id)
        {
            var branch = DbSet.Where(a => a.BranchId == id).Select(b => new
            {
                BranchId = b.BranchId,
                Name = b.Name,
                Address = b.Address,
                Contact = b.Contact,
                Web = b.Web,
                Email = b.Email,
                CompanyId = b.CompanyId
            }).FirstOrDefault();


            return branch;
        }
        public Branch GetById(int id)
        {
            return DbSet.Where(b => b.BranchId == id).FirstOrDefault();
        }
        public bool GetDuplicate(int companyId,string name)
        {
            var branch = DbSet.Where(c => c.Name.ToLower() == name.ToLower() && c.CompanyId == companyId).FirstOrDefault();
            return (branch != null) ? true : false;
        }
    }
}