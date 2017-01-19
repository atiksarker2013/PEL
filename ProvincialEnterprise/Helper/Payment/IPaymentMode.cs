using ProvincialEnterprise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProvincialEnterprise.Helper.Payment
{
    public interface IPaymentMode
    {
        void AddPayment(PurchaseHead purchase, JournalDetail jrDetail, string journalNo, int purchaseId);
    }
}
