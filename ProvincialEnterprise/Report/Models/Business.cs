using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Report.Models
{
    public class Business
    {
        public ReportViewModel GetMyPurchaseRepoertViewModel(List<object> dataSet, string ReportFileName, ReportViewModel.ReportFormat format = ReportViewModel.ReportFormat.PDF)
        {
           // ReportFileName = "Purchase Invoice";
            var reportViewModel = new ReportViewModel
            {
               
                FileName =  "~/Report/" + ReportFileName + ".rdlc",

                //ReportTitle = "Cantonment Public School and College, Rangpur",

                Format = format,
                ViewAsAttachment = false
            };

            //adding the dataset information to the report view model object
            reportViewModel.ReportDataSets.Add(new ReportViewModel.ReportDataSet { DataSetData = dataSet, DatasetName = "PurchaseInvoicDataSet" });
            return reportViewModel;
        }
    }
}