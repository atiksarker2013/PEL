app.controller("purCtrl", function ($scope, purService) {   
    //getAllItems();
    //getAllModels();
    //getAllSuppliers();
    //getAccount();
    getPaymentMode();
    // getBanks();


    //$scope.addUpdatePurchase = function () {
    //    var Purchase = {
    //        InvoiceNo: $scope.invoiceNo          
    //    };
    //    //var getCCLimitAction = $scope.Action;
    //    //if (getCCLimitAction == "Update") {
    //    //    CCLimit.Id = $scope.id;
    //    //    var getCCLimithData = cclimitService.updateCCLimit(CCLimit);
    //    //    getCCLimithData.then(function (msg) {
    //    //        $scope.getCCLimits();
    //    //        alert(msg.data);
    //    //        ClearFields();
    //    //    }, function () {
    //    //        alert('Error in updating record');
    //    //    });
    ////} else {

    //        var getCCLimithData = purService.addUpdatePurchase(Purchase);
    //        getCCLimithData.then(function (msg) {
    //           // $scope.getCCLimits();
    //            alert(msg.data);
    //            ClearFields();
    //        }, function () {
    //            alert('Error in adding record');
    //        });
    //    //}
    //}

    //function getAllItems() {
    //    var getItemData = purService.getItems();
    //    getItemData.then(function (item) {
    //        $scope.items = item.data;
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

    //function getAllModels() {
    //    var getModelData = purService.getModels();
    //    getModelData.then(function (model) {
    //        $scope.models = model.data;
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

    getAllCompanies();
    getCustomerBanks();
   // getUnits();

    function getAllCompanies() {
        var getCompanyData = purService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting compannies record");
        });
    }

    function getCustomerBanks() {
        var getCustomerBankData = purService.getCustomerBanks();
        getCustomerBankData.then(function (bank) {
            $scope.customerBanks = bank.data;
        }, function () {
            alert("Error getting customer banks record");
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getSectionData = purService.getAllBranchesByCompany(companyId);
        getSectionData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting branches records');
        });
    }

    $scope.getAllSuppliers = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var supplierId = $scope.supplierId;
        var getSupplierData = purService.getSuppliers(companyId, branchId, supplierId);
        getSupplierData.then(function (supplier) {
            $scope.suppliers = supplier.data;
        }, function () {
            alert('Error in getting suppliers records');
        });
    }

    //$scope.getModelById = function (modelId) {
    //    //var modelId = $scope.modelId;
    //    var getModelData = purService.getModel(modelId);
    //    getModelData.then(function (_model) {
    //        $scope.model = _model.data;
    //        $scope.modelId = model.ModelId;
    //        //$scope.itemId = model.ItemId;
    //        $scope.modelName = model.ModelName;
    //        //$scope.price = model.Price;
    //        //$scope.qty = model.Qty;
    //        //$scope.salePrice = model.SalePrice;
    //        //$scope.reorderQty = model.ReorderQty;
    //        //$scope.isWarranty = model.IsWarranty;
    //        //$scope.avgCost = model.AvgCost;
    //        //$scope.branchId = model.BranchId;
    //        //$scope.Action = "Update";
    //    }, function () {
    //        alert('Error in getting model records');
    //    });
    //}


    //$scope.getSuppliersByCode = function () {
    //    var suppliercode = $scope.suppliercode;
    //    var getSupplierData = purService.getSuppliersByCode(suppliercode);
    //    getSupplierData.then(function (_supplier) {
    //        $scope.supplier = _supplier.data;
    //    }, function () {
    //        alert('Error in getting supplier records');
    //    });
    //}

    $scope.getAccount = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var mainHeadId = 4;
        var getAccountData = purService.getAccount(companyId, branchId, mainHeadId);
        getAccountData.then(function (account) {
            $scope.accounts = account.data;
        }, function () {
            alert('Error in getting accounts records');
        });
    }

    $scope.getItems = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getItemData = purService.getItems(companyId, branchId);
        getItemData.then(function (item) {
            $scope.items = item.data;
        }, function () {
            alert('Error in getting items records');
        });
    }

    $scope.getModels = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var itemId = $scope.itemId;
        var modelId = $scope.modelId;
        var getItemData = purService.getModels(companyId, branchId, itemId, modelId);
        getItemData.then(function (model) {
            $scope.models = model.data;
        }, function () {
            alert('Error in getting models records');
        });
    }

    $scope.getUnits = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;     
        var getunitData = purService.getUnits(companyId, branchId);
        getunitData.then(function (unit) {
            $scope.units = unit.data;
        }, function () {
            alert('Error in getting units records');
        });
    }

    function getPaymentMode() {
        var getAccountData = purService.getPaymentMode();
        getAccountData.then(function (paymentMode) {
            $scope.paymentModes = paymentMode.data;
        }, function () {
            alert('Error in getting panyments records');
        });
    }

    $scope.getBanks = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getBankData = purService.getBanks(companyId, branchId);
        getBankData.then(function (bank) {
            $scope.banks = bank.data;
        }, function () {
            alert('Error in getting banks records');
        });
    }

    function getPurchaseList() {
        var getPurchaseData = purService.getPurchaseList();
        getPurchaseData.then(function (purchase) {
            $scope.purchases = purchase.data;
        }, function () {
            alert('Error in getting purchase  records');
        });
    }
    //$scope.editSupplier = function (supplier) {
    //    var getSupplierData = suppService.getSupplier(supplier.SupplierId);
    //    getSupplierData.then(function (_supplier) {
    //        $scope.supplier = _supplier.data;
    //        $scope.supplierId = supplier.SupplierId;
    //        $scope.name = supplier.Name;
    //        $scope.address = supplier.Address;
    //        $scope.contact = supplier.Contact;
    //        $scope.fax = supplier.Fax;
    //        $scope.email = supplier.Email;
    //        $scope.branchId = supplier.BranchId;
    //        $scope.ownerName = supplier.OwnerName;
    //        $scope.Action = "Update";
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

    $scope.getPurchases = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getPurchaseData = purService.getPurchases(companyId, branchId);
        getPurchaseData.then(function (purchase) {
            $scope.purchases = purchase.data;
        }, function () {
            alert('Error in getting purchases records');
        });
    }

    //$scope.getPurchaseDetails = function () {
    //    var companyId = $scope.companyId;
    //    var branchId = $scope.branchId;
    //    var purchaseId = $scope.purchaseId;
    //    var getPurchaseData = purService.getPurchaseDetails(companyId, branchId, purchaseId);
    //    getPurchaseData.then(function (purchaseDetail) {
    //        $scope.purchaseDetails = purchaseDetail.data;
    //    }, function () {
    //        alert('Error in getting purchase details records');
    //    });
    //}

    $scope.getPurchaseDetails = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var purchaseId = $scope.purchaseId;
        var getPurchaseData = purService.getPurchaseDetails(companyId, branchId, purchaseId);
        getPurchaseData.then(function (purchaseDetail) {
            $scope.purchaseDetails = purchaseDetail.data;
        }, function () {
            alert('Error in getting purchase details records');
        });
    }

    $scope.editPurchase = function (purchase) {
        var getPurchaseData = purService.getPurchaseById(purchase.CompanyId, purchase.BranchId, purchase.PurchaseId);
        getPurchaseData.then(function (_purchase) {
            $scope.purchase = _purchase.data;
            $scope.purchaseId = purchase.PurchaseId;
            $scope.invoiceNo = purchase.InvoiceNo;
            $scope.supplierId = purchase.SupplierId;
            $scope.accountId = purchase.AccountId;
            $scope.purchaseDate = purchase.PurchaseDate;
            $scope.totalAmount = purchase.TotalAmount;
            $scope.disountAmount = purchase.DisountAmount;
            $scope.grantTotal = purchase.GrantTotal;
            $scope.dueAmount = purchase.DueAmount;
            $scope.bankId = purchase.BankId;
            $scope.checkNo = purchase.CheckNo;
            $scope.checkDate = purchase.CheckDate;
            $scope.checkMDate = purchase.CheckMDate;
            $scope.payAmount = purchase.PayAmount;
            $scope.customerBankId = purchase.CustomerBankId;
          
            $scope.branchId = purchase.BranchId;
            $scope.name = purchase.Name;
            $scope.companyId = purchase.CompanyId;
            $scope.name = purchase.name;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting purchase records');
        });
    }
  
    $scope.getPurchaseById = function (purchase) {
        var getPurchaseData = purService.getPurchaseById(purchase.CompanyId, purchase.BranchId, purchase.PurchaseId);
        getPurchaseData.then(function (msg) {
            alert(msg.data);
            // ClearFields();
        }, function () {
            alert('Error in get purchase details record');
        });
    }

    //$scope.editPurchaseDetails = function (unit) {
    //    var getUnitData = unitService.getUnitById(unit.UnitId);
    //    getUnitData.then(function (_unit) {
    //        $scope.unit = _unit.data;
    //        $scope.unitId = unit.UnitId;
    //        $scope.unitName = unit.UnitName;
    //        $scope.branchId = unit.BranchId;
    //        $scope.name = unit.Name;
    //        $scope.companyId = unit.CompanyId;
    //        $scope.name = unit.name;
    //        $scope.Action = "Update";
    //    }, function () {
    //        alert('Error in getting unit records');
    //    });
    //}

    $scope.addUpdatePurchase = function () {
        var Purchase = {
            InvoiceNo: $scope.invoiceNo,
            AccountId: $scope.accountId,
            SupplierId: $scope.supplierId,
            PurchaseDate: $scope.purchaseDate,
            ItemId: $scope.itemId,
            ModelId: $scope.modelId,
            UnitId: $scope.unitId,
            Qty: $scope.qty,
            UnitPice: $scope.unitPrice,
            Serial: $scope.serial,
        }
    
        var getPurchaseData = purService.addPurchase(Purchase);
        getPurchaseData.then(function (msg) {
            getPurchaseList();
            //alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in adding purchase record');
        });
        
    }

    //$scope.reportPDF = function (purchase) {
    //    var getPurchaseData = purService.reportPDF(purchase.invoiceNo);
    //    getPurchaseData.then(function (msg) {
    //        alert(msg.data);
    //        // ClearFields();
    //    }, function () {
    //        alert('Error in get purchase details record');
    //    });
    //}

    //$scope.reportPDF = function (purchase) {
    //    //var invoiceNo = $scope.invoiceNo;
    //    var getReportData = purService.reportPDF(purchase.invoiceNo);
    //    getReportData.then(function (purchaseInvoice) {
    //        $scope.purchaseInvoices = purchaseInvoice.data;
    //    }, function () {
    //        alert('Error in getting branches records');
    //    });
    //}

    function reportPDF() {
        var deferred = $q.defer();
        $http.get('/api/Report').success(function (results) {
            window.open('/api/Report', '_self', '');
            deferred.resolve(results);
        }).error(function (data, status, headers, config) {
            deferred.reject('Failed generate pdf');
        });

        return deferred.promise;
    }

    $scope.reportPDF = function () {
        reportPDF();
    }

    //$scope.save = function () {
    //    $scope.$broadcast('show-errors-check-validity');

    //    if ($scope.Purchase.$invalid) { return; }
    //}

    //$scope.deleteSupplier = function (supplier) {
    //    var getSupplierData = suppService.deleteSupplier(supplier.SupplierId);
    //    getSupplierData.then(function (msg) {
    //        getAllSuppliers();
    //        alert(msg.data);
    //        ClearFields();
    //    }, function () {
    //        alert('Error in deleting record');
    //    });
    //}

    //function ClearFields() {
    //    //$scope.supplierId = "";
    //    //$scope.name = "";
    //    //$scope.address = "";
    //    //$scope.contact = "";
    //    //$scope.fax = "";
    //    //$scope.email = "";
    //    //$scope.branchId = "";
    //    //$scope.ownerName = "";
    //    $scope.itemId = "";
    //    $scope.modelId = "";
    //    $scope.unitId = "";
    //    $scope.qty = "";
    //    $scope.unitPrice = "";
    //    $scope.serial = "";
    //    $scope.Action = "Add";
    //}

    //$scope.Cancel = function () {
    //    ClearFields();
    //}

    //$scope.submitForm = function () {

    //    // Set the 'submitted' flag to true
    //    $scope.submitted = true;

    //    if ($scope.userForm.$valid) {
    //        alert("Form is valid!");
    //    }
    //    else {
    //        alert("Please correct errors!");
    //    }
    //};
})