using ProvincialEnterprise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ProvincialEnterprise.Controllers
{
    public class ReportController : ApiController
    {
        PELEntities pel = new PELEntities();
        [HttpGet]
        public async Task<HttpResponseMessage> GetPDFReport(string p)
        {
            string fileName = string.Concat("PurchaseInvoice.pdf");
            string filePath = HttpContext.Current.Server.MapPath("~/Report/" + fileName);
            //PurchaseController purchase = new PurchaseController();
            List<PurchaseDetailPurchase> PurchaseInvoiceList = pel.GetPurchaseDetailByPurchase(p).ToList();


            await ProvincialEnterprise.Report.ReportGenerator.GeneratePDF(PurchaseInvoiceList, filePath);

            HttpResponseMessage result = null;
            result = Request.CreateResponse(HttpStatusCode.OK);
            result.Content = new StreamContent(new FileStream(filePath, FileMode.Open));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = fileName;

            return result;
        }
    }
}
