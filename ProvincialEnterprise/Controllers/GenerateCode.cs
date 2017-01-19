using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvincialEnterprise.Controllers
{
    public class GenerateCode
    {
        public string GetJournalNo(string str)
        {
            string x = string.Empty;
            if (str == null)
            {
                x = "jr" + "1";
            }
            else
            {
                x = str.Substring(2);
                int y = Convert.ToInt32(x) + 1;
                x = "jr" + y;
            }
            return x;
        }
    }
}
