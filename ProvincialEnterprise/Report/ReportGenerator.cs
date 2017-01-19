using Microsoft.Reporting.WebForms;
using ProvincialEnterprise.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace ProvincialEnterprise.Report
{
    public class ReportGenerator
    {
        public static string Report = "ProvincialEnterprise.Report.PurchaseInvoice.rdlc";

        public static Task GeneratePDF(List<PurchaseDetailPurchase> datasource, string filePath)
        {
            return Task.Run(() =>
            {
                string binPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
                var assembly = Assembly.Load(System.IO.File.ReadAllBytes(binPath + "\\ProvincialEnterprise.dll"));

                using (Stream stream = assembly.GetManifestResourceStream(Report))
                {
                    var viewer = new ReportViewer();
                    viewer.LocalReport.EnableExternalImages = true;
                    viewer.LocalReport.LoadReportDefinition(stream);

                    Warning[] warnings;
                    string[] streamids;
                    string mimeType;
                    string encoding;
                    string filenameExtension;

                    viewer.LocalReport.DataSources.Add(new ReportDataSource("PurchaseInvoicDataSet", datasource));

                    viewer.LocalReport.Refresh();

                    byte[] bytes = viewer.LocalReport.Render(
                        "PDF", null, out mimeType, out encoding, out filenameExtension,
                        out streamids, out warnings);

                    using (FileStream fs = new FileStream(filePath, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            });
        }
    }
}