using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProvincialEnterprise.Models;
using ProvincialEnterprise.Models.Repository;


namespace ProvincialEnterprise.Models
{
    public class CommonPel
    {
        PELEntities pel = new PELEntities();
        PurchaseDetailByPurchaseRepository db = new PurchaseDetailByPurchaseRepository();

        public dynamic GetPurchaseDetails(string companyId, string branchId, string purchaseId)
        {
            var purchaseDetails = pel.PurchaseDetails.Select(d => new
            {
               d.PurchaseDetailId,
               d.SerialNo,
               d.ItemId,
               d.ModelId,
               d.UnitId,
               d.Qty,
               d.UnitPice,
               d.PurchaseId,
               d.InvoiceNo
            }).Join(pel.PurchaseHeads, d => d.PurchaseId, p => p.PurchaseId, (d, p) => new
            {
               d.PurchaseDetailId,
               d.SerialNo,
               d.ItemId,
               d.ModelId,
               d.UnitId,
               d.Qty,
               d.UnitPice,
               d.PurchaseId,
               d.InvoiceNo,
               p.BranchId

            }).Join(pel.Branches, p => p.BranchId, b => b.BranchId, (p, b) => new
            {
                p.PurchaseDetailId,
                p.SerialNo,
                p.ItemId,
                p.ModelId,
                p.UnitId,
                p.Qty,
                p.UnitPice,
                p.PurchaseId,
                p.InvoiceNo,
                p.BranchId,
                BranchName= b.Name,
                b.CompanyId
               
            }).Join(pel.Companies, b => b.CompanyId, c => c.CompanyId, (b, c) => new
            {
                b.PurchaseDetailId,
                b.SerialNo,
                b.ItemId,
                b.ModelId,
                b.UnitId,
                b.Qty,
                b.UnitPice,
                b.PurchaseId,
                b.InvoiceNo,
                b.BranchId,
                b.BranchName,
                b.CompanyId,
                CompanyName= c.Name
                 
            }).ToList();

            if ((companyId != "null" && branchId == null && purchaseId == null) || (companyId != "null" && branchId == "null"))
            {
                purchaseDetails = purchaseDetails.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null && branchId.All(char.IsDigit) && purchaseId == null)
            {
                purchaseDetails = purchaseDetails.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != null && branchId.All(char.IsDigit) && purchaseId != null && purchaseId.All(char.IsDigit))
            {
                purchaseDetails = purchaseDetails.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.PurchaseId == Convert.ToInt32(purchaseId)
                                                ).ToList();
            }
            else
                purchaseDetails = null;


            return purchaseDetails;
        }
        public dynamic GetPurchases(string companyId, string branchId)
        {
            var purchases = pel.PurchaseHeads.Select(p => new
                {
                    p.PurchaseId,
                    p.InvoiceNo,
                    p.SupplierId,
                    p.AccountId,
                    p.PaymentModeId,
                    p.PurchaseDate,
                    p.TotalAmount,
                    p.DisountAmount,
                    p.GrantTotal,
                    p.DueAmount,
                    p.BankId,
                    p.CheckNo,
                    p.CheckDate,
                    p.CheckMDate,
                    p.PayAmount,
                    p.BranchId,
                    p.CustomerBankId
                }).Join(pel.Branches, p => p.BranchId, b => b.BranchId, (p, b) => new
                {
                    p.PurchaseId,
                    p.InvoiceNo,
                    p.SupplierId,
                    p.AccountId,
                    p.PaymentModeId,
                    p.PurchaseDate,
                    p.TotalAmount,
                    p.DisountAmount,
                    p.GrantTotal,
                    p.DueAmount,
                    p.BankId,
                    p.CheckNo,
                    p.CheckDate,
                    p.CheckMDate,
                    p.PayAmount,
                    p.BranchId,
                    p.CustomerBankId,
                    b.Name,
                    b.CompanyId                
                }).Join(pel.Companies, b => b.CompanyId, c => c.CompanyId, (b, c) => new 
                {
                    b.PurchaseId,
                    b.InvoiceNo,
                    b.SupplierId,
                    b.AccountId,
                    b.PaymentModeId,
                    b.PurchaseDate,
                    b.TotalAmount,
                    b.DisountAmount,
                    b.GrantTotal,
                    b.DueAmount,
                    b.BankId,
                    b.CheckNo,
                    b.CheckDate,
                    b.CheckMDate,
                    b.PayAmount,
                    b.BranchId,
                    b.CustomerBankId,
                    BranchName = b.Name,
                    b.CompanyId,
                    CompanyName = c.Name
                }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                purchases = purchases.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                purchases = purchases.Where(x => x.CompanyId == Convert.ToInt32(companyId) && x.BranchId == Convert.ToInt32(branchId)).ToList();
            }
            else
                purchases = null;


            return purchases;
        }
        public dynamic GetPurchaseDetailByPurchase(string invoiceno)
        {
            // var context = new PELEntities();
            // var pdps = context.PurchaseDetailByPurchase(invoiceno);
           // List<PurchaseDetailPurchase> pdpList = new List<PurchaseDetailPurchase>();
            if (invoiceno != null && invoiceno != "null")
            {
                var pdps = pel.GetPurchaseDetailByPurchase(invoiceno);
                //foreach (PurchaseDetailPurchase pdp in pdps)
                //{
                //    pdpList.Add(pdp);

                //}
                return pdps;
            }
            else
                return null;
            //var query = pel.Database.SqlQuery(
            //       "EXEC [dbo].[GetFunctionByID] @p1",
            //new SqlParameter("p1", 200));

            // add NoTracking() if required

            // Fetch the results
            //var result = query.ToList();
            // var pdPurchase=pel.


            //if (invoiceno != null && invoiceno != "null")
            //{
            //    var pdPurchase = pel.PurchaseDetailByPurchase(invoiceno);
            //    return pdPurchase;
            //}
            //else
            //    return null;

        }
        public dynamic GetPurchaseDetailById(int purchasedetailid)
        {
            //  var purchaseDetailByPurchase = DbSet.Where(d => d.InvoiceNo==invoiceNo).ToList();
            //var purchaseDetailPurchase = pel.PurchaseDetailById(purchasedetailid).Select(d => new
            //{
            //    d.PurchaseId,
            //    d.InvoiceNo,
            //    d.AccountId,
            //    d.AccountName,
            //    d.BankId,
            //    d.BankName,
            //    d.BranchId,
            //    d.BranchName,
            //    d.CompanyId,
            //    d.CompanyName,
            //    d.CheckDate,
            //    d.CheckMDate,
            //    d.CheckNo,
            //    d.CustomerBankId,
            //    d.CustomerBankName,
            //    d.DisountAmount,
            //    d.DueAmount,
            //    d.GrantTotal,
            //    d.PayAmount,
            //    d.PaymentModeId,
            //    d.PaymentType,
            //    d.PurchaseDate,
            //    d.SupplierId,
            //    d.SupplierName,
            //    d.TotalAmount,
            //    d.PurchaseDetailId,
            //    d.ModelId,
            //    d.ModelName,
            //    d.ItemId,
            //    d.ItemName,
            //    d.UnitId,
            //    d.UnitName,
            //    d.SerialNo,
            //    d.Qty,
            //    d.UnitPice

            //}).FirstOrDefault();

            //return purchaseDetailPurchase;

            var purchases = pel.PurchaseDetails.Where(d => d.PurchaseDetailId == purchasedetailid).Select(d => new
            {
                d.PurchaseId,
                d.InvoiceNo,
                d.PurchaseDetailId,
                d.ItemId,
                ItemName = d.Item.ItemName,
                d.ModelId,
                ModelName = d.Model.ModelName,
                d.UnitId,
                UnitName = d.Unit.UnitName,
                d.Qty,
                d.UnitPice,
                d.SerialNo,
                d.SerialId

            }).Join(pel.PurchaseHeads, u => u.PurchaseId, p => p.PurchaseId, (u, p) => new
            {
                PurchaseId = u.PurchaseId,
                InvoiceNo = u.InvoiceNo,
                AccountId = p.AccountId,
                AccountName = p.Account.AccountName,
                BankId = p.BankId,
                BankName = p.Bank.BankName,
                BranchId = p.BranchId,
                BranchName = p.Branch.Name,
                CompanyId = p.Branch.CompanyId,
                CompanyName = p.Branch.Company.Name,
                CheckDate = p.CheckDate.ToString(),
                CheckMDate = p.CheckMDate.ToString(),
                CheckNo = p.CheckNo,
                CustomerBankId = p.CustomerBankId,
                CustomerBankName = p.CustomerBank.Name,
                DisountAmount = p.DisountAmount,
                DueAmount = p.DueAmount,
                GrantTotal = p.GrantTotal,
                PayAmount = p.PayAmount,
                PaymentModeId = p.PaymentModeId,
                PaymentType = p.PaymentMode.PaymentType,
                PurchaseDate = p.PurchaseDate.ToString(),
                SupplierId = p.SupplierId,
                SupplierName = p.Supplier.Name,
                TotalAmount = p.TotalAmount,
                PurchaseDetailId = u.PurchaseDetailId,
                ItemId = u.ItemId,
                ItemName = u.ItemName,
                ModelId = u.ModelId,
                ModelName = u.ModelName,
                UnitId = u.UnitId,
                UnitName = u.UnitName,
                Qty = u.Qty,
                UnitPice = u.UnitPice,
                SerialNo = u.SerialNo,
                SerialId=u.SerialId
            }).FirstOrDefault();

            //if (purchasedetailid == null)
            //{
            //    purchases = purchases.Where(x => x.PurchaseDetailId == Convert.ToInt32(purchasedetailid)).FirstOrDefault();
            //}

            //else
            //    purchases = null;


            return purchases;

        }     
        public dynamic GetUnits(string companyId, string branchId)
        {
            var units = pel.Units.Select(u => new
            {
                u.UnitId,
                u.UnitName,
                u.BranchId
            }).Join(pel.Branches, u => u.BranchId, b => b.BranchId, (u, b) => new
            {
                u.UnitId,
                u.UnitName,
                u.BranchId,
                b.Name,
                b.CompanyId
            }).Join(pel.Companies, b => b.CompanyId, c => c.CompanyId, (b, c) => new
            {
                b.UnitId,
                b.UnitName,
                b.BranchId,
                BranchName = b.Name,
                b.CompanyId,
                CompanyName = c.Name
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                units = units.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                units = units.Where(x => x.CompanyId == Convert.ToInt32(companyId) && x.BranchId == Convert.ToInt32(branchId)).ToList();
            }
            else
                units = null;


            return units;
        }

        public dynamic GetCCLimits(string companyId, string branchId, string bankId)
        {
            var cclimit = pel.CCLimits.Select(c => new
            {
                c.Id,
                c.BankId,
                // BankName = c.Bank.BankName,
                c.LimitAmount,
                EntryDate = c.EntryDate.ToString(),
                c.BranchId
            }).Join(pel.Banks, c => c.BankId, b => b.BankId, (c, b) => new
            {
                c.Id,
                c.BankId,
                BankName = b.BankName,
                c.LimitAmount,
                c.EntryDate,
                c.BranchId,

            }).Join(pel.Branches, c => c.BranchId, b => b.BranchId, (c, b) => new
            {
                c.Id,
                c.BankId,
                c.BankName,
                c.LimitAmount,
                c.EntryDate,
                c.BranchId,
                BranchName = b.Name,
                b.CompanyId
            }).Join(pel.Companies, b => b.CompanyId, i => i.CompanyId, (b, i) => new
            {
                b.CompanyId,
                b.Id,
                b.BankId,
                b.BankName,
                b.LimitAmount,
                b.EntryDate,
                b.BranchId,
                b.BranchName,
                CompanyName = i.Name
            }).ToList();

            if ((companyId != "null" && branchId == null && bankId == null) || (companyId != "null" && branchId == "null"))
            {
                cclimit = cclimit.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null && branchId.All(char.IsDigit) && bankId == null)
            {
                cclimit = cclimit.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != null && branchId.All(char.IsDigit) && bankId != null && bankId.All(char.IsDigit))
            {
                cclimit = cclimit.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.BankId == Convert.ToInt32(bankId)
                                                ).ToList();
            }
            else
                cclimit = null;


            return cclimit;
        }

        public dynamic GetSections(string companyId, string branchId)
        {
            var sections = pel.Sections.Select(x => new
            {
                x.BranchId,
                x.SectionId,
                Name = x.Name
            }).Join(pel.Branches, s => s.BranchId, b => b.BranchId, (s, b) => new
            {
                BranchName = b.Name,
                b.CompanyId,
                s.SectionId,
                b.BranchId,
                SectionName = s.Name
            }).Join(pel.Companies, x => x.CompanyId, i => i.CompanyId, (x, i) => new
            {
                CompanyName = i.Name,
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                CompanyId = x.CompanyId,
                Name = x.SectionName,
                SectionId = x.SectionId
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                sections = sections.Where(c => c.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != "null")
            {
                sections = sections.Where(c => c.CompanyId == Convert.ToInt32(companyId)
                                        && c.BranchId == Convert.ToInt32(branchId)).ToList();
            }
            else
                sections = null;
            
            return sections;
        }


        public dynamic GetAllDesignations(string companyId, string branchId, string sectionId)
        {
            var designations = pel.Designations.Select(d => new
            {
                d.DesignationId,
                d.Name,
                d.SectionId
            }).Join(pel.Sections, x => x.SectionId, s => s.SectionId, (x, s) => new
            {
                s.BranchId,
                Name = x.Name,
                x.DesignationId,
                x.SectionId,
                SectionName = s.Name
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                Name = x.Name,
                b.CompanyId,
                x.BranchId,
                x.DesignationId,
                x.SectionId,
                SectionName = x.SectionName
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                Name = x.Name,
                c.CompanyId,
                x.BranchId,
                x.DesignationId,
                x.SectionId,
                SectionName = x.SectionName
            }).ToList();

            if ((companyId != "null" && branchId == null && sectionId == "null") || (companyId != "null" && branchId == "null"))
            {
                designations = designations.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if ((companyId != "null" && branchId != null && sectionId == null) || (companyId != "null" && branchId != null && sectionId == "null"))
            {
                designations = designations.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != null && sectionId != null)
            {

                designations = designations.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                            && x.BranchId == Convert.ToInt32(branchId)
                                            && x.SectionId == Convert.ToInt32(sectionId)
                                            ).ToList();

            }
            else
                return null;

            return designations;
        }

        public dynamic GetMarketing(string companyId, string branchId)
        {
            var marketing = pel.Markets.Select(m => new
            {
                m.BranchId,
                m.MarketId,
                m.MarketName,
                m.Contact
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.BranchId,
                x.MarketId,
                x.MarketName,
                x.Contact,
                b.Name,
                b.CompanyId
            }).Join(pel.Companies, x => x.CompanyId, i => i.CompanyId, (x, i) => new
            {
                CompanyName = i.Name,
                BranchId = x.BranchId,
                BranchName = x.Name,
                CompanyId = x.CompanyId,
                x.MarketId,
                x.MarketName,
                x.Contact
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                marketing = marketing.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                marketing = marketing.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else
                marketing = null;
            

            return marketing;
        }

        public dynamic GetCCLimit(string companyId, string branchId)
        {
            var cclimit = pel.CCLimits.Select(c => new
            {   
                c.BranchId,          
                c.Id,
                c.BankId,
                c.LimitAmount,
                c.EntryDate
                

            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.BranchId,
                x.Id,
                x.BankId,
                x.LimitAmount,
                x.EntryDate,
                b.Name,
                b.CompanyId
            }).Join(pel.Companies, x => x.CompanyId, i => i.CompanyId, (x, i) => new
            {
                CompanyName = i.Name,
                BranchId = x.BranchId,
                BranchName = x.Name,
                CompanyId = x.CompanyId,
                x.Id,
                x.BankId,
                x.LimitAmount,
                x.EntryDate
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                cclimit = cclimit.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                cclimit = cclimit.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else
                cclimit = null;


            return cclimit;
        }

        public dynamic GetMainHead(string companyId, string branchId, string accountTypeId)
        {
            var mainHeads = pel.AccountTypes.Select(a => new
            {
                a.Name,
                a.Id
            }).Join(pel.MainHeads, x => x.Id, m => m.AccountTypeId, (x, m) => new
            {
                AccountTypeName = x.Name,
                m.Name,
                m.BranchId,
                m.MainHeadId,
                m.AccountTypeId
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                AccountTypeName = x.AccountTypeName,
                x.Name,
                x.MainHeadId,
                b.CompanyId,
                b.BranchId,
                BranchName = b.Name,
                x.AccountTypeId
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                x.AccountTypeName,
                x.Name,
                x.MainHeadId,
                x.CompanyId,
                x.BranchId,
                x.AccountTypeId,
                x.BranchName
            }).ToList();

            if ((companyId != "null" && branchId == null && accountTypeId == null) || (companyId != "null" && branchId == "null"))
            {
                mainHeads = mainHeads.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null && accountTypeId == null)
            {
                mainHeads = mainHeads.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != null && accountTypeId != null)
            {
                mainHeads = mainHeads.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.AccountTypeId == Convert.ToInt32(accountTypeId)
                                                ).ToList();
            }
            else
                return null;

            return mainHeads;
        }

        public dynamic GetLedgers(string companyId, string branchId, string mainHeadId)
        {
            var ledgers = pel.Accounts.Select(a => new
            {
                a.AccountId,
                Name = a.AccountName,
                a.MainHeadId
            }).Join(pel.MainHeads, x => x.MainHeadId, h => h.MainHeadId, (x, h) => new
            {
                x.AccountId,
                x.Name,
                MainAccount = h.Name,
                h.BranchId,
                h.MainHeadId
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.AccountId,
                x.Name,
                x.MainAccount,
                BranchName = b.Name,
                b.BranchId,
                x.MainHeadId,
                b.CompanyId
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                x.AccountId,
                x.Name,
                x.MainAccount,
                x.MainHeadId,
                x.BranchName,
                x.BranchId,
                c.CompanyId
            }).ToList();

            if ((companyId != "null" && branchId == null && mainHeadId == null) || (companyId != "null" && branchId == "null"))
            {
                ledgers = ledgers.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if ((companyId != "null" && branchId != null && mainHeadId == null) || (companyId != "null" && branchId != null && mainHeadId == "null"))
            {
                ledgers = ledgers.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != null && mainHeadId != null)
            {
                ledgers = ledgers.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.MainHeadId == Convert.ToInt32(mainHeadId)
                                                ).ToList();
            }
            else
                return null;

            return ledgers;
        }

        public dynamic GetBanks(string companyId, string branchId)
        {
            var banks = pel.Banks.Select(b => new
            {
                b.BranchId,
                b.BankId,
                b.BankName,
                b.Branch,
                b.AccountNo,
                b.Opening
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.BankId,
                x.BankName,
                x.Branch,
                x.AccountNo,
                x.Opening,
                b.CompanyId,
                x.BranchId,
                BranchName = b.Name
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                x.BankId,
                x.BankName,
                x.Branch,
                x.AccountNo,
                x.Opening,
                CompanyName = c.Name,
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                CompanyId = x.CompanyId,
                Name = x.BankName
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                banks = banks.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                banks = banks.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else
                banks = null;
            

            return banks;
        }

        public dynamic GetCustomers(string companyId, string branchId)
        {
            var customers = pel.Customers.Select(b => new
            {
                b.CustomerId,
                b.CustomerName,
                b.Address,
                b.Telephone,
                b.OwnerName,
                b.EmailId,
                b.CompanyCode,
                b.BranchId
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.CustomerId,
                x.CustomerName,
                x.Address,
                x.Telephone,
                x.OwnerName,
                x.EmailId,
                x.CompanyCode,
                b.CompanyId,
                x.BranchId,
                BranchName = b.Name
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                CompanyName = c.Name,
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                CompanyId = x.CompanyId,
                x.CustomerId,
                x.CustomerName,
                x.Address,
                x.Telephone,
                x.OwnerName,
                x.EmailId,
                x.CompanyCode
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                customers = customers.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                customers = customers.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else
                customers = null;
            

            return customers;
        }

        public dynamic GetSuppliers(string companyId, string branchId, string supplierId)
        {
            var suppliers = pel.Suppliers.Select(s => new
            {
                s.SupplierId,
                s.Name,
                s.Address,
                s.Contact,
                s.OwnerName,
                s.Email,
                s.Fax,
                s.BranchId,
                s.AccountId,
                s.SupplierCode
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.SupplierId,
                x.Name,
                x.Address,
                x.Contact,
                x.OwnerName,
                x.Email,
                x.Fax,
                b.CompanyId,
                x.BranchId,
                x.AccountId,
                BranchName = b.Name,
                x.SupplierCode
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                CompanyName = c.Name,
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                CompanyId = x.CompanyId,
                x.SupplierId,
                x.Name,
                x.Address,
                x.Contact,
                x.OwnerName,
                x.Email,
                x.Fax,
                x.AccountId,
                x.SupplierCode
            }).ToList();

            if ((companyId != "null" && branchId == null && supplierId == null) || (companyId != "null" && branchId == "null"))
            {
                suppliers = suppliers.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != "null" && branchId != null && supplierId == null)
            {
                suppliers = suppliers.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != "null" && branchId != null && supplierId != null && supplierId != "null")
            {
                suppliers = suppliers.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.SupplierId == Convert.ToInt32(supplierId)
                                                ).ToList();
            }
            else
            {
                suppliers = null;
            }

            return suppliers;
        }

        public dynamic GetItems(string companyId, string branchId)
        {
            var items = pel.Items.Select(i => new
            {
                i.ItemId,
                i.ItemName,
                i.BranchId
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                x.ItemId,
                x.ItemName,
                b.CompanyId,
                x.BranchId,
                BranchName = b.Name
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                CompanyName = c.Name,
                BranchId = x.BranchId,
                BranchName = x.BranchName,
                CompanyId = x.CompanyId,
                x.ItemId,
                x.ItemName
            }).ToList();

            if ((companyId != "null" && branchId == null) || (companyId != "null" && branchId == "null"))
            {
                items = items.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if (companyId != "null" && branchId != null)
            {
                items = items.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else
            {
                items = null;
            }

            return items;
        }

        public dynamic GetModels(string companyId, string branchId, string itemId, string modelId)
        {
            var models = pel.Models.Select(m => new
            {
                m.ModelId,
                m.ModelName,
                m.Price,
                m.SalePrice,
                m.Qty,
                m.ReorderQty,
                m.ItemId
            }).Join(pel.Items, x => x.ItemId, i => i.ItemId, (x, i) => new
            {
                x.ModelId,
                x.ModelName,
                x.Price,
                x.SalePrice,
                x.Qty,
                x.ReorderQty,
                x.ItemId,
                i.ItemName,
                i.BranchId
            }).Join(pel.Branches, x => x.BranchId, b => b.BranchId, (x, b) => new
            {
                b.CompanyId,
                x.ModelId,
                x.ModelName,
                x.Price,
                x.SalePrice,
                x.Qty,
                x.ReorderQty,
                x.ItemId,
                x.ItemName,
                x.BranchId,
                BranchName = b.Name
            }).Join(pel.Companies, x => x.CompanyId, c => c.CompanyId, (x, c) => new
            {
                c.CompanyId,
                c.Name,
                x.ModelId,
                x.ModelName,
                x.Price,
                x.SalePrice,
                x.Qty,
                x.ReorderQty,
                x.ItemId,
                x.ItemName,
                x.BranchId,
                x.BranchName
            }).ToList();

            if ((companyId != "null" && branchId == null && itemId == null && modelId == null) || (companyId != "null" && branchId == "null" && branchId != "null" && modelId == "null"))
            {
                models = models.Where(x => x.CompanyId == Convert.ToInt32(companyId)).ToList();
            }
            else if ((companyId != "null" && branchId != null && itemId == null && modelId == null) || (companyId != "null" && branchId != "null" && itemId == "null" && modelId=="null"))
            {
                models = models.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                ).ToList();
            }
            else if ((companyId != "null" && branchId != null && itemId != null && modelId == null) || (companyId != "null" && branchId != "null" && itemId != "null" && modelId == "null"))
            {
                models = models.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.ItemId == Convert.ToInt32(itemId)
                                                ).ToList();
            }
            else if (companyId != "null" && branchId != null && itemId != null && modelId != "null")
            {
                models = models.Where(x => x.CompanyId == Convert.ToInt32(companyId)
                                                && x.BranchId == Convert.ToInt32(branchId)
                                                && x.ItemId == Convert.ToInt32(itemId)
                                                && x.ModelId == Convert.ToInt32(modelId)
                                                ).ToList();
            }
            else
                return null;

            return models;
        }
    }
}