using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;

namespace ProvincialEnterprise.Report.Models
{
    public class ReportViewModel
    {
        public enum ReportFormat
        {
            PDF = 1,
            Word = 2,
            Excel = 3
        }

        public ReportViewModel()
        {
            //initation for the data set holder
            ReportDataSets = new List<ReportDataSet>();
        }

        //Name of the report
        public string Name { get; set; }

        //Language of the report
        public string ReportLanguage { get; set; }

        //Reference to the RDLC file that contain the report definition
        public string FileName { get; set; }

        //The main title for the reprt
        public string ReportTitle { get; set; }

        //The right and left titles and sub title for the report
        public string RightMainTitle { get; set; }
        public string RightSubTitle { get; set; }
        public string LeftMainTitle { get; set; }
        public string LeftSubTitle { get; set; }

        //the url for the logo, 
        public byte[] ReportLogo { get; set; }

        //date for printing the report
        public DateTime ReportDate { get; set; }

        //the user name that is printing the report
        public string UserNamPrinting { get; set; }

        //dataset holder
        public IList<ReportDataSet> ReportDataSets { get; set; }

        //report format needed
        public ReportFormat Format { get; set; }
        public bool ViewAsAttachment { get; set; }

        //an helper class to store the data for each report data set
        public class ReportDataSet
        {
            public string DatasetName { get; set; }
            public IList<object> DataSetData { get; set; }
            public IList<object> DataSetData1 { get; set; }
        }

        public string ReporExportFileName
        {
            get { return string.Format("attachment; filename={0}.{1}", this.ReportTitle, ReporExportExtention); }
        }

        public string ReporExportExtention
        {
            get
            {
                switch (this.Format)
                {
                    case ReportViewModel.ReportFormat.Word:
                        return ".doc";
                    case ReportViewModel.ReportFormat.Excel:
                        return ".xls";
                    default:
                        return ".pdf";
                }
            }
        }

        public string LastmimeType
        {
            get { return mimeType; }
        }

        private string mimeType;

        public byte[] RenderReport()
        {
            //geting repot data from the business object

            //creating a new report and setting its path
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = System.Web.HttpContext.Current.Server.MapPath(this.FileName);

            //adding the reort datasets with there names
            foreach (var dataset in this.ReportDataSets)
            {
                ReportDataSource reportDataSource = new ReportDataSource(dataset.DatasetName, dataset.DataSetData);
                localReport.DataSources.Add(reportDataSource);
            }
            //enabeling external images
            localReport.EnableExternalImages = true;

            //localReport.SetParameters(new ReportParameter("ReportTitle", this.ReportTitle));
            //localReport.SetParameters(new ReportParameter("ReportLogo", System.Web.HttpContext.Current.Server.MapPath(this.ReportLogo)));
            //localReport.SetParameters(new ReportParameter("ReportDate", this.ReportDate.ToShortDateString()));
            //localReport.SetParameters(new ReportParameter("UserNamPrinting", this.UserNamPrinting));

            //preparing to render the report

            string reportType = this.Format.ToString();

            string encoding;
            string fileNameExtension;

            //The DeviceInfo settings should be changed based on the reportType
            //http//msdn2.microsoft.com/en-us/library/ms.aspx
            string deviceInfo =
                "<DeviceInfo>" +
                "  <OutputFormat>" + this.Format.ToString() + "</OutputFormat>" +
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            //Render the report
            renderedBytes = localReport.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

            return renderedBytes;
        }
    }
}