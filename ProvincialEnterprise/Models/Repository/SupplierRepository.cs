using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class SupplierRepository : Repository<Supplier>
    {
        public Supplier GetById(int id)
        {
            return DbSet.Where(c => c.SupplierId == id).FirstOrDefault();
        }

        public dynamic GetSuppliers()
        {
            var suppliers = DbSet.Select(s => new
            {
                SupplierId = s.SupplierId,
                AccountId = s.AccountId,
                Name = s.Name,
                Address = s.Address,
                Contact = s.Contact,
                Fax = s.Fax,
                Email = s.Email,
                OwnerName = s.OwnerName,
                BranchId = s.BranchId,
                BranchName = s.Branch.Name,
                SupplierCode = s.SupplierCode

            }).ToList();

            return suppliers;
        }

        public dynamic GetSuppliersByCode(string supplierCode)
        {
            var suppliers = DbSet.Where(c => c.SupplierCode == supplierCode).Select(s => new
            {
                SupplierId = s.SupplierId,
                AccountId = s.AccountId,
                Name = s.Name,
                Address = s.Address,
                Contact = s.Contact,
                Fax = s.Fax,
                Email = s.Email,
                OwnerName = s.OwnerName,
                BranchId = s.BranchId,
                BranchName = s.Branch.Name,
                SupplierCode = s.SupplierCode

            });

            return suppliers;
        }


        public dynamic GetSupplierById(int id)
        {
            var supplier = DbSet.Where(s => s.SupplierId == id)
                .Select(x => new
                {
                    SupplierId = x.SupplierId,
                    Name = x.Name,
                    Address = x.Address,
                    Contact = x.Contact,
                    Fax = x.Fax,
                    Email = x.Email,
                    OwnerName = x.OwnerName,
                    BranchId = x.BranchId,
                    SupplierCode = x.SupplierCode
                });
            return supplier;
        }
        public bool GetDuplicate(int branchId,string name)
        {
            var supplier = DbSet.Where(c => c.Name.ToLower() == name.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (supplier != null) ? true : false;
        }

        public dynamic GetSupplierByAccoutId(int id)
        {
            var supplier = DbSet.Where(c => c.AccountId == id).FirstOrDefault();
            return supplier;
        }
         //x == null ? null : x.JournalNo
        public dynamic GetAccountIdBySupplierId(int id)
        {
            var accountId = DbSet.Where(c => c.SupplierId == id).Select(x => x.AccountId).FirstOrDefault();
            return (accountId != null) ? accountId : 0;
        }
    }
}