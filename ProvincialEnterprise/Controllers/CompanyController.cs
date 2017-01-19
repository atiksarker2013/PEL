using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;

namespace ProvincialEnterprise.Controllers
{
    public class CompanyController : Controller
    {
        CompanyRepository repository = new CompanyRepository();
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetAllCompanies()
        {
            var companies = repository.GetCompanies(); //GetAll();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyById(string id)
        {
            var companyId = Convert.ToInt32(id);
            var company = repository.GetCompanyById(companyId);
            return Json(company, JsonRequestBehavior.AllowGet);
        }

        public string UpdateCompany(Company company)
        {
            if (company != null)
            {
                int companyId = Convert.ToInt32(company.CompanyId);
                Company _company = repository.Get(companyId);
                _company.Name = company.Name;
                _company.Address = company.Address;
                _company.Contact = company.Contact;
                repository.SaveChanges();
                return "Company record updated successfully";
            }
            else
            {
                return "Invalid company record";
            }
        }

        public string AddCompany(Company company)
        {
            if (company != null)
            {
                if (repository.GetDuplicate(company.Name.Trim()))
                {
                    return "Duplicate record is found."; 
                }
                else
                {
                    repository.Add(company);
                    repository.SaveChanges();
                    return "Company record added successfully";
                }
            }
            else
            {
                return "Invalid company record";
            }
        }

        public string DeleteCompany(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                try
                {
                    int companyId = Int32.Parse(id);

                    var company = repository.Get(companyId);
                    repository.Delete(company);
                    repository.SaveChanges();
                    return "Selected company record deleted sucessfully";

                }
                catch (Exception)
                {
                    return "Company details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }
}