using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvincialEnterprise.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Camera()
        {
            ViewBag.Camera = "class=active";
            ViewBag.Product = "class=active dropdown";
            //var productList = repository.GetProductDetails();
            //ViewBag.ProductList = productList.Where(p => p.CategoryName == "Camera").ToList();
            return View();
        }

        public ActionResult AccessControlDevice()
        {
            ViewBag.Device = "class=active";
            ViewBag.Product = "class=active dropdown";
            //var productList = repository.GetProductDetails();
            //ViewBag.ProductList = productList.Where(p => p.CategoryName == "Access Control Device").ToList();
            return View();
        }

        public ActionResult Software()
        {
            ViewBag.Device = "class=active";
            ViewBag.Product = "class=active dropdown";
            //var productList = repository.GetProductDetails();
            //ViewBag.ProductList = productList.Where(p => p.CategoryName == "Access Control Device").ToList();
            return View();
        }

        public ActionResult Laptop()
        {
            ViewBag.Laptop = "class=active";
            ViewBag.Product = "class=active dropdown";
            //var productList = repository.GetProductDetails();
            //ViewBag.ProductList = productList.Where(p => p.CategoryName == "Laptop").ToList();
            return View();
        }

        public ActionResult ComputerAccessories()
        {
            ViewBag.Accessories = "class=active";
            ViewBag.Product = "class=active dropdown";
            //var productList = repository.GetProductDetails();
            //ViewBag.ProductList = productList.Where(p => p.CategoryName == "Computer Accessories").ToList();
            return View();
        }
        
    }
}
	
