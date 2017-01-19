app.service("purService", function ($http) {

    //this.getSuppliers = function () {
    //    return $http.get("/Supplier/GetAllSupliers");
    //}

    this.addUpdatePurchase= function (purchase) {
        var response = $http({
            method: "post",
            url: "/Report/GetPDFReport",
            data: JSON.stringify(purchase),
            dataType: "json"
        });
        return response;
    }

    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
    }

    this.getCustomerBanks = function () {
        return $http.get("/CustomerBank/GetAllBanks");
    }

    this.getAllBranchesByCompany = function (companyId) {
        var response = $http({
            method: "post",
            url: "/Branch/GetAllBranchesByCompany",
            params: {
                id: JSON.stringify(companyId)
            }
        });
        return response;
    }

    this.getSuppliers = function (companyId, branchId, supplierId) {
        var response = $http({
            method: "post",
            url: "/Supplier/GetSuppliers",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                supplierId: JSON.stringify(supplierId)

            }
        });
        return response;
    }

    //this.getModel = function (modelId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/Model/GetModelById",
    //        params: {
    //            id: JSON.stringify(modelId)
    //        }
    //    });
    //    return response;
    //}

    //this.getSuppliersByCode = function (suppliercode) {
    //    var response = $http({
    //        method: "post",
    //        url: "/Supplier/GetSuppliersByCode",
    //        params: {
             
    //            suppliercode: JSON.stringify(suppliercode)
    //        }
    //    });
    //    return response;
    //};

    this.getAccount = function (companyId, branchId, mainHeadId) {
        //return $http.get("/Ledger/GetAllAccounts");
        var response = $http({
            method: "post",
            url: "/Ledger/GetLedgers",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                mainHeadId: JSON.stringify(mainHeadId)
            }
        });
        return response;
    }

    this.getItems = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/Item/GetItems",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }

    this.getModels = function (companyId, branchId, itemId, modelId) {
        var response = $http({
            method: "post",
            url: "/Model/GetModels",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                itemId: JSON.stringify(itemId),
                modelId: JSON.stringify(modelId)
            }
        });
        return response;
    }


    this.getUnits = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/Unit/GetUnits",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
            }
        });
        return response;
    }

    this.getBanks = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/Bank/GetBanks",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }


    //this.getAccount = function () {
    //    return $http.get("/Ledger/GetAllPurchaseAccounts");
    //};
    //this.getAccount = function () {
    //    //var response = $http({
    //    //    method: "post",
    //    //    url: "/Ledger/GetAccountById",
    //    //    params: {
    //    //        id: JSON.stringify(9)
    //    //    }
    //    //});
    //    return $http.get("/Ledger/GetAccountById/9");
    //    //return response;
    //}

    //this.getItems = function () {
    //    return $http.get("/Item/GetAllItems");
    //};

    //this.getModels = function () {
    //    return $http.get("/Model/GetAllModels");
    //};

    this.getPaymentMode = function() {
        return $http.get("/PaymentMode/GetAllPaymentModes");
    }

    //this.getBanks = function () {
    //    return $http.get("/Bank/GetAllBanks");
    //}

    this.getPurchaseList = function () {
        return $http.get("/Purchase/GetPurchaseList");
    }


    //this.updateSupplier = function (supplier) {
    //    var response = $http({
    //        method: "post",
    //        url: "/Supplier/UpdateSuppler",
    //        data: JSON.stringify(supplier),
    //        dataType: "json"
    //    });
    //    return response;
    //}

    this.getPurchases = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetPurchases",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }

    //this.getPurchaseDetails = function (purchaseId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/PurchaseReturn/GetPurchaseDetails",
    //        params: {
    //            purchaseId: JSON.stringify(purchaseId)
    //        }
    //    });
    //    return response;
    //}

    this.getPurchaseDetails = function (companyId, branchId, purchaseId) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetPurchaseDetails",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                purchaseId: JSON.stringify(purchaseId)
            }
        });
        return response;
    }

    this.getPurchaseById = function (companyId, branchId, purchaseId) {
        var response = $http({
            method: "post",
            url: "/PurchaseReturn/getPurchaseById",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                purchaseId: JSON.stringify(purchaseId)

            }
        });
        return response;
    }

    
    //this.getPurchaseDetailById = function (purchase) {
    //    var response = $http({
    //        method: "post",
    //        url: "/PurchaseReturn/getPurchaseDetailById",
    //        data: JSON.stringify(purchase),
    //        dataType: "json"
    //    });
    //    return response;
    //}

    //// get Purchase by purchaseId
    //this.getPurchaseById = function (companyId, branchId, purchaseId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/PurchaseReturn/GetPurchaseById",
    //        params: {
    //            companyId: JSON.stringify(companyId),
    //            branchId: JSON.stringify(branchId),
    //            purchaseId: JSON.stringify(purchaseId)
    //        }
    //    });
    //    return response;
    //}


    //// Update Purchase 
    //this.updatePurchase = function (purchase) {
    //    var response = $http({
    //        method: "post",
    //        url: "/Purchase/UpdatePurchase",
    //        data: JSON.stringify(purchase),
    //        dataType: "json"
    //    });
    //    return response;
    //}
    //this.getPurchaseById = function (purchase) {
    //    var response = $http({
    //        method: "post",
    //        url: "/PurchaseReturn/GetPurchaseById",
    //        data: JSON.stringify(purchase),
    //        dataType: "json"
    //    });
    //    return response;
    //}

    this.addPurchase = function (purchase) {
        var response = $http({
            method: "post",
            url: "/Purchase/Add",
            data: JSON.stringify(purchase),
            dataType: "json"
        });
        return response;
    }

    //function reportPDF() {
    //    var deferred = $q.defer();
    //    $http.get('/api/Report').success(function (results) {
    //        window.open('/api/Report', '_self', '');
    //        deferred.resolve(results);
    //    }).error(function (data, status, headers, config) {
    //        deferred.reject('Failed generate pdf');
    //    });

    //    return deferred.promise;
    //};

    this.reportPDF = function (invoiceNo) {
        var response = $http({
            method: "post",
            url: "/Purchase/GetPDFReport",
            params: {
                invoiceNo: JSON.stringify(invoiceNo),
            }
        });
        return response;
    }


    //this.getPurchaseById = function (companyId, branchId, purchaseId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/PurchaseReturn/getPurchaseById",
    //        params: {
    //            companyId: JSON.stringify(companyId),
    //            branchId: JSON.stringify(branchId),
    //            purchaseId: JSON.stringify(purchaseId)

    //        }
    //    });
    //    return response;
    //}

    //this.deleteSupplier = function (supplierId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/Supplier/DeleteSupplier",
    //        params: {
    //            id: JSON.stringify(supplierId)
    //        }
    //    });
    //    return response;
    //}


    //return {
    //    require: 'ngModel',
    //    link: function (scope, currentEl, attrs, ctrl) {
    //        var comparefield = document.getElementsByName(attrs.ngCompare)[0]; //getting first element
    //        compareEl = angular.element(comparefield);

    //        //current field key up
    //        currentEl.on('keyup', function () {
    //            if (compareEl.val() != "") {
    //                var isMatch = currentEl.val() === compareEl.val();
    //                ctrl.$setValidity('compare', isMatch);
    //                scope.$digest();
    //            }
    //        });

    //        //Element to compare field key up
    //        compareEl.on('keyup', function () {
    //            if (currentEl.val() != "") {
    //                var isMatch = currentEl.val() === compareEl.val();
    //                ctrl.$setValidity('compare', isMatch);
    //                scope.$digest();
    //            }
    //        });
    //    }
    //}
})