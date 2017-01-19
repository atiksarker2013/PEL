using ProvincialEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialEnterprise.Helper.ChequeInformation
{
    public interface IChequeInfo
    {
        void AddChequeInfo(ChequeInfo chequeInfo, PurchaseHead purchase);
    }
}
