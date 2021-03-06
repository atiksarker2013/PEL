﻿using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvincialEnterprise.Helper.Payment
{
    public class OnlinePaymentcs : IPaymentMode
    {
        SupplierRepository sRepository = new SupplierRepository();
        JournalDetailRepository jdRepository = new JournalDetailRepository();

        public void AddPayment(PurchaseHead purchase, JournalDetail jrDetail, string journalNo, int purchaseId)
        {
            jrDetail = new JournalDetail();
            int accountId = sRepository.GetAccountIdBySupplierId(Convert.ToInt32(purchase.SupplierId));
            //Debit
            jrDetail.JournalNo = journalNo;
            jrDetail.PurchaseId = purchaseId;
            jrDetail.AccountId = purchase.AccountId;           
            jrDetail.TransAccountId = accountId; // purchase.SupplierId;
            jrDetail.Debit = purchase.PayAmount;
            jrDetail.Credit = 0;
            jrDetail.PaymentModeId = purchase.PaymentModeId;
            jrDetail.ChecqueNo = purchase.CheckNo;
            jrDetail.ChequeDate = purchase.CheckDate;
            jrDetail.ChequeMDate = purchase.CheckDate;
            jrDetail.TransDate = purchase.PurchaseDate;
            jrDetail.BranchId = purchase.BranchId;
            jdRepository.Add(jrDetail);
            jdRepository.SaveChanges();

            //Credit
            jrDetail.JournalNo = journalNo;
            jrDetail.PurchaseId = purchaseId;
            jrDetail.AccountId = accountId; // purchase.SupplierId;
            jrDetail.TransAccountId = purchase.AccountId;
            jrDetail.Debit = 0;
            jrDetail.Credit = purchase.PayAmount;
            jrDetail.PaymentModeId = purchase.PaymentModeId;
            jrDetail.ChecqueNo = purchase.CheckNo;
            jrDetail.ChequeDate = purchase.CheckDate;
            jrDetail.ChequeMDate = purchase.CheckDate;
            jrDetail.TransDate = purchase.PurchaseDate;
            jrDetail.BranchId = purchase.BranchId;
            jdRepository.Add(jrDetail);
            jdRepository.SaveChanges();
        }
    }
}