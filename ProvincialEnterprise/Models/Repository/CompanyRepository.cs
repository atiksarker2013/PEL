using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class CompanyRepository : Repository<Company>
    {
        public Company GetById(int id)
        {
            return DbSet.Where(c => c.CompanyId == id).FirstOrDefault();
        }

        public bool GetDuplicate(string name)
        {
            var company = DbSet.Where(c => c.Name.ToLower() == name.ToLower()).FirstOrDefault();
            return (company != null) ? true : false;
        }
        public dynamic GetCompanies()
        {
            var companies = DbSet.Select(c => new
            {
                CompanyId = c.CompanyId,
                Name = c.Name,
                Address = c.Address,
                Contact = c.Contact
            }).ToList();

            return companies;
        }

        public dynamic GetCompanyById(int id)
        {
            var company = DbSet.Where(a => a.CompanyId == id).Select(c => new
            {
                CompanyId = c.CompanyId,
                Name = c.Name,
                Address = c.Address,
                Contact = c.Contact
            }).FirstOrDefault();

            return company;
        }
    }
}