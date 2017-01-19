using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Models.Repository
{
    public class ChequeInfoReository :Repository<ChequeInfo>
    {
        public dynamic GetChequeInfoById(int pId)
        {
            var chkInfo = DbSet.Where(c => c.PurchaseId == pId).Select(k => new
                {
                    k.ChequeInfoId,
                    k.TransactionDate,
                    k.ChequeDate,
                    k.ChequeMDate,
                    k.AccountId,
                    k.BankId,
                    k.CustomerBankId,
                    k.Amount,
                    k.ChequeType,
                    k.FinalStatus,
                    k.Bounched,
                    k.BounchedDate,
                    k.ReIssue,
                    k.ReIssueDate,
                    k.CashPayStart,
                    k.ChequeCancel,
                    k.ChequeCancelDate,
                    k.Remarks,
                    k.PurchaseId,
                    k.SaleId,
                    k.RPId,
                    k.BranchId
                }).FirstOrDefault();

            return chkInfo;
        
        }

    }
}