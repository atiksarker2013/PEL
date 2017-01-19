using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class JournalDetailRepository :Repository<JournalDetail>
    {
        public string GetMaxValue()
        {
            return DbSet.Max(x => x == null ? null : x.JournalNo);
        }

        public dynamic GetJournalDetailByPurchaseId(int purchaseId)
        {
            var jds = DbSet.Where(j => j.PurchaseId == purchaseId).Select(j => new
            {
                j.JournalDetailId,
                j.JournalNo,
                j.PurchaseId,
                j.TransDate,
                j.AccountId,
                j.Debit,
                j.Credit,
                j.ChecqueNo,
                j.ChequeDate,
                j.ChequeMDate,
                j.PaymentModeId,
                j.TransAccountId,
                j.RPID,
                j.MarketId,
                j.BranchId

            }).ToList();
            return jds;
        
        }
    }
}