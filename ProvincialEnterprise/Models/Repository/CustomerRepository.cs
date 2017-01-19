using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class CustomerRepository : Repository<Customer>
    {
        public Customer GetById(int id)
        {
            return DbSet.Where(c => c.CustomerId == id).FirstOrDefault();
        }
        public dynamic GetCustomers()
        {
            var customers = DbSet.Select(c => new
            {
                CustomerId = c.CustomerId,
                CustomerName = c.CustomerName,
                MarketId = c.MarketId,
                MarketName = c.Market.MarketName,
                Address = c.Address,
                OwnerName = c.OwnerName,
                Telephone = c.Telephone,
                Email = c.EmailId,
                NationalId = c.NID,
                TradeLicense = c.TradeLicense,
                CheckNo = c.ChequeNo,
                CheckAmount = c.ChequeAmount,
                BankId = c.BankId,
                BankName = c.CustomerBank.Name,
                CompanCode = c.CompanyCode,
                BranchId = c.BranchId,
                BranchName = c.Branch.Name
            }).ToList();

            return customers;
        }

        public dynamic GetCustomerById(int id)
        {
            var customer = DbSet.Where(c=> c.CustomerId == id).Select(c => new
            {
                CustomerId = c.CustomerId,
                Name = c.CustomerName,
                MarketId = c.MarketId,
                MarketName = c.Market.MarketName,
                Address = c.Address,
                OwnerName = c.OwnerName,
                Telephone = c.Telephone,
                Email = c.EmailId,
                NationalId = c.NID,
                TradeLicense = c.TradeLicense,
                CheckNo = c.ChequeNo,
                CheckAmount = c.ChequeAmount,
                BankId = c.BankId,
                BankName = c.CustomerBank.Name,
                CompanCode = c.CompanyCode,
                BranchId = c.BranchId,
                BranchName = c.Branch.Name
            });

            return customer;
        }

        public bool GetDuplicate(int branchId,string name)
        {
            var customer = DbSet.Where(c => c.CustomerName.ToLower() == name.ToLower() && c.BranchId == branchId).FirstOrDefault();
            return (customer != null) ? true : false;
        }

        public dynamic GetCustomerByAccoutId(int id)
        {
            var customer = DbSet.Where(c => c.AcountId == id).FirstOrDefault();
            return customer;
        }
    }
}