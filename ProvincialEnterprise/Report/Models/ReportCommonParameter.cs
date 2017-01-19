using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Report.Models
{
    public class ReportCommonParameter
    {
        public string ReportName { get; set; }
        public byte[] Logo { get; set; }
        public string ReportTitle { get; set; }
        public string ReportSubTitle { get; set; }
        public string ReportFooter { get; set; }
    }
}