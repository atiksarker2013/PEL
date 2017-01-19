app.controller("pdCtrl", function ($scope, pdService) {

    //getAllDesignations();
    //getAllSections();

    getAllCompanies();
    getAllBranches();
    getAllSuppliers();
    getAccounts();
    getItems();
    getModels();
    getUnits();
    getPaymentModes();
    getBanks();
    getCustomerBanks();


    function getAllCompanies() {
        var getCompanyData = pdService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
        //$scope.purchaseId = null;
    }

    function getAllBranches() {
        var getBranchData = pdService.getBranches();
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting branches records');
        });
    }

    function getAllSuppliers() {
        var getSupplierData = pdService.getSuppliers();
        getSupplierData.then(function (supplier) {
            $scope.suppliers = supplier.data;
        }, function () {
            alert('Error in getting suppliers records');
        });
    }

    function getAccounts() {
        var getAccountData = pdService.getAccounts();
        getAccountData.then(function (account) {
            $scope.accounts = account.data;
        }, function () {
            alert('Error in getting accounts records');
        });
    }

    function getItems() {
        var getItemData = pdService.getItems();
        getItemData.then(function (item) {
            $scope.items = item.data;
        }, function () {
            alert('Error in getting items records');
        });
    }

    function getModels() {
        var getItemData = pdService.getModels();
        getItemData.then(function (model) {
            $scope.models = model.data;
        }, function () {
            alert('Error in getting models records');
        });
    }

    function getUnits() {
        var getunitData = pdService.getUnits();
        getunitData.then(function (unit) {
            $scope.units = unit.data;
        }, function () {
            alert('Error in getting units records');
        });
    }

    function getPaymentModes() {
        var getPaymentModeData = pdService.getPaymentModes();
        getPaymentModeData.then(function (paymentMode) {
            $scope.paymentModes = paymentMode.data;
        }, function () {
            alert('Error in getting payment mode records');
        });
    }

    function getBanks() {
        var getBankData = pdService.getBanks();
        getBankData.then(function (bank) {
            $scope.banks = bank.data;
        }, function () {
            alert('Error in getting bank records');
        });
    }

    function getCustomerBanks() {
        var getCustomerBankData = pdService.getCustomerBanks();
        getCustomerBankData.then(function (customerBank) {
            $scope.customerBanks = customerBank.data;
        }, function () {
            alert('Error in getting customer bank records');
        });
    }

    $scope.getAllPurchaseDetails = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var sectionId = $scope.sectionId;
        var getPurchaseDetailData = pdService.getPurchaseDetails(companyId, branchId, purchaseId);
        getPurchaseDetailData.then(function (purchaseDetail) {
            $scope.purchaseDetails = purchaseDetail.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllPurchasesByBranch = function () {
        var branchId = $scope.branchId;
        var getPurchaseData = pdService.getPurchaseByBranch(branchId);
        getPurchaseData.then(function (purchase) {
            $scope.purchases = purchase.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getPurchaseDetailByPurchase = function () {
        var invoiceno = $scope.invoiceno;
        var getPurchaseDetailData = pdService.getPurchaseDetailByPurchase(invoiceno);
        getPurchaseDetailData.then(function (purchaseDetail) {
            $scope.purchasedetails = purchaseDetail.data;
        }, function () {
            alert('Error in getting purchase details records');
        });
    }

    $scope.getPurchaseByInvoiceNo = function () {
        var invoiceno = $scope.invoiceno;
        var getPurchaseData = pdService.getPurchaseByInvoiceNo(invoiceno);
        getPurchaseData.then(function (purchase) {
            $scope.purchases = purchase.data;
        }, function () {
            alert('Error in getting purchase records');
        });
    }

    $scope.editPurchaseDetail = function (pd) {
        var getPurchaseDetailData = pdService.getPurchaseDetailById(pd.PurchaseDetailId);

        getPurchaseDetailData.then(function (_purchaseDetail) {
            $scope.pd = _purchaseDetail.data;
            //$scope.serialNo = purchaseDetail.SerialNo;
            //$scope.purchaseDetailId = purchaseDetail.PurchaseDetailId;
            $scope.purchaseId = pd.PurchaseId;
            $scope.invoiceNo = pd.InvoiceNo;
            $scope.accountId = pd.AccountId;
            $scope.accountName = pd.AccountName;
            $scope.bankId = pd.BankId;
            $scope.bankName = pd.BankName;
            $scope.branchId = pd.BranchId;
            $scope.branchName = pd.BranchName;
            $scope.companyId = pd.CompanyId;
            $scope.companyName = pd.CompanyName;
            $scope.checkDate = pd.CheckDate;
            $scope.checkMDate = pd.CheckMDate;
            $scope.checkNo = pd.CheckNo;
            $scope.customerBankId = pd.CustomerBankId;
            $scope.customerBankName = pd.CustomerBankName;
            $scope.disountAmount = pd.DisountAmount;
            $scope.dueAmount = pd.DueAmount;
            $scope.grantTotal = pd.GrantTotal;
            $scope.payAmount = pd.PayAmount;
            $scope.paymentModeId = pd.PaymentModeId;
            $scope.paymentType = pd.PaymentType;
            $scope.purchaseDate = pd.PurchaseDate;
            $scope.supplierId = pd.SupplierId;
            $scope.supplierName = pd.SupplierName;
            $scope.totalAmount = pd.TotalAmount;
            $scope.purchaseDetailId = pd.PurchaseDetailId;
            $scope.modelId = pd.ModelId;
            $scope.modelName = pd.ModelName;
            $scope.itemId = pd.ItemId;
            $scope.itemName = pd.ItemName;
            $scope.unitId = pd.UnitId;
            $scope.unitName = pd.UnitName;
            $scope.serialNo = pd.SerialNo;
            $scope.qty = pd.Qty;
            $scope.unitPice = pd.UnitPice;
            $scope.serialId = pd.SerialId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }


    //$scope.editPurchase = function (purchase) {
    //    var getPurchaseData = pdService.getPurchaseByInvoiceNo(purchase.InvoiceNo);
    //    getPurchaseData.then(function (_purchase) {
    //        $scope.purchase = _purchase.data;
    //        $scope.purchaseId = purchase.PurchaseId;
    //        $scope.invoiceNo = purchase.InvoiceNo;
    //        $scope.supplierId = purchase.SupplierId;
    //        $scope.accountId = purchase.AccountId;
    //        $scope.purchaseDate = purchase.PurchaseDate;
    //        $scope.totalAmount = purchase.TotalAmount;
    //        $scope.disountAmount = purchase.DisountAmount;
    //        $scope.grantTotal = purchase.GrantTotal;
    //        $scope.dueAmount = purchase.DueAmount;
    //        $scope.bankId = purchase.BankId;
    //        $scope.checkNo = purchase.CheckNo;
    //        $scope.checkDate = purchase.CheckDate;
    //        $scope.checkMDate = purchase.CheckMDate;
    //        $scope.payAmount = purchase.PayAmount;
    //        $scope.customerBankId = purchase.CustomerBankId;

    //        $scope.branchId = purchase.BranchId;
    //        $scope.name = purchase.BranchName;
    //        $scope.companyId = purchase.CompanyId;
    //        $scope.name = purchase.CompanyName;
    //        $scope.Action = "Update";
    //    }, function () {
    //        alert('Error in getting purchase records');
    //    });
    //}

    $scope.addUpdatePurchase = function () {
        var Purchase = {
            InvoiceNo: $scope.invoiceNo,
            //PurchaseId: $scope.purchaseId,
            AccountId: $scope.accountId,
            BankId: $scope.bankId,
            BranchId: $scope.branchId,
            CompanyId: $scope.companyId,
            CheckDate: $scope.checkDate,
            CheckMDate: $scope.checkMDate,
            CheckNo: $scope.checkNo,
            CustomerBankId: $scope.customerBankId,
            DisountAmount: $scope.disountAmount,
            DueAmount: $scope.dueAmount,
            GrantTotal: $scope.grantTotal,
            PayAmount: $scope.payAmount,
            PaymentModeId: $scope.paymentModeId,
            PaymentType: $scope.paymentType,
            PurchaseDate: $scope.purchaseDate,
            SupplierId: $scope.supplierId,
            TotalAmount: $scope.totalAmount,
            PurchaseDetailId: $scope.purchaseDetailId,
            ModelId: $scope.modelId,
            ItemId: $scope.itemId,
            UnitId: $scope.unitId,
            SerialNo: $scope.serialNo,
            Qty: $scope.qty,
            UnitPice: $scope.unitPice,
            SerialId: $scope.serialId
          
        };
        var getPurchaseAction = $scope.Action;
        if (getPurchaseAction == "Update") {
            Purchase.PurchaseId = $scope.purchaseId;
            var getPurchaseData = pdService.updatePurchase(Purchase);
            getPurchaseData.then(function (msg) {
                $scope.getPurchaseDetailByPurchase();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getCCLimithData = cclimitService.addCCLimit(CCLimit);
            getCCLimithData.then(function (msg) {
                $scope.getPurchaseDetailByPurchase();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    //$scope.addUpdatePurchase = function () {
    //   var Purchase = {
    //        InvoiceNo: $scope.invoiceNo,
    //        PurchaseId: $scope.purchaseId,
    //        AccountId: $scope.accountId,
    //        BankId: $scope.bankId,
    //        BranchId: $scope.branchId,
    //        CompanyId: $scope.companyId,
    //        CheckDate: $scope.checkDate,
    //        CheckMDate: $scope.checkMDate,
    //        CheckNo: $scope.checkNo,
    //        CustomerBankId: $scope.customerBankId,
    //        DisountAmount: $scope.disountAmount,
    //        DueAmount: $scope.dueAmount,
    //        GrantTotal: $scope.grantTotal,
    //        PayAmount: $scope.payAmount,
    //        PaymentModeId: $scope.paymentModeId,
    //        PaymentType: $scope.paymentType,
    //        PurchaseDate: $scope.purchaseDate,
    //        SupplierId: $scope.supplierId,
    //        TotalAmount: $scope.totalAmount,
    //        PurchaseDetailId: $scope.purchaseDetailId,
    //        ModelId: $scope.modelId,
    //        ItemId: $scope.itemId,
    //        UnitId: $scope.unitId,
    //        SerialNo: $scope.serialNo,
    //        Qty: $scope.qty,
    //        UnitPice: $scope.unitPice,
    //        SerialId: $scope.serialId
    //    };
    //    var purchaseDetailAction = $scope.Action;
    //    if (purchaseDetailAction == "Update") {
    //        //PurchaseDetail.PurchaseDetailId = $scope.purchaseDetailId;
    //        PurchaseDetail.PurchaseId = $scope.purchaseId;
    //        //PurchaseDetail.InvoiceNo = $scope.invoiceNo
    //        var getPurchaseData = pdService.updatePurchaseDetail(Purchase);
    //        getPurchaseData.then(function (msg) {
    //            $scope.getPurchaseDetailByPurchase();
    //            alert(msg.data);
    //        }, function () {
    //            alert('Error in updating record');
    //        });
    //    } else {
    //        var getPurchaseDetailData = pdService.addPurchaseDetail(Purchase);
    //        getPurchaseDetailData.then(function (msg) {
    //            $scope.getAllPurchaseDetails();
    //            alert(msg.data);
    //            ClearFields();
    //        }, function () {
    //            alert('Error in add record');
    //        });
    //    }
    //}

    $scope.deletePurchaseDetail = function (purchaseDetail) {
        var getPurchaseDetailData = pdService.deletePurchaseDetail(purchaseDetail.PurchaseDetailId);
        getPurchaseDetailData.then(function (msg) {
            $scope.getAllPurchaseDetails();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.designationId = "";
        $scope.name = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
})