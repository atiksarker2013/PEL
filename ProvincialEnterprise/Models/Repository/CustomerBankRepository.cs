using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class CustomerBankRepository: Repository<CustomerBank>
    {
        public CustomerBank GetById(int id)
        {
            return DbSet.Where(c => c.BankId == id).FirstOrDefault();
        }

        public dynamic GetCustomerBanks()
        {
            var customerBank = DbSet.Select(c => new
            {
                BankId = c.BankId,
                Name = c.Name
            }).ToList();

            return customerBank;
        }

        public dynamic GetBankById(int id)
        {
            var customerBank = DbSet.Where(c => c.BankId == id).Select(b => new
            {
                BankId = b.BankId,
                Name = b.Name
            }).FirstOrDefault();

            return customerBank;
        }
        public bool GetDuplicate(string name)
        {
            var customarBank = DbSet.Where(c => c.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return (customarBank != null) ? true : false;
        }
    }
}