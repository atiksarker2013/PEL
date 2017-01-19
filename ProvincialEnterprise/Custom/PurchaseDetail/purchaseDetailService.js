app.service("pdService", function ($http) {

    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
    }

    this.getBranches = function () {
        return $http.get("/Branch/GetAllBranches");
    }

    this.getSuppliers = function () {
        return $http.get("/Supplier/GetAllSuppliers");
    }

    this.getAccounts = function () {
        return $http.get("/Ledger/GetAllAccounts");
    }

    this.getItems = function () {
        return $http.get("/Item/GetAllItems");
    }


    this.getModels = function () {
        return $http.get("/Model/GetAllModels");
    }


    this.getUnits = function () {
        return $http.get("/Unit/GetAllUnits");
    }

    this.getPaymentModes = function () {
        return $http.get("/PaymentMode/GetAllPaymentModes");
    }

    this.getBanks = function () {
        return $http.get("/Bank/GetAllBanks");
    }

    this.getCustomerBanks = function () {
        return $http.get("/CustomerBank/GetAllBanks");
    }

   
    //this.getCompanies = function () {
    //    return $http.get("/PurchaseDetail/GetAllPurchase");
    //}

    this.getPurchaseDetails = function (companyId, branchId, purchaseId) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetAllPurchaseDetail",
            params: {
                id: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                purchaseId: JSON.stringify(purchaseId)
            }
        });
        return response;
    }

    //this.getAllSections = function () {
    //    return $http.get("/Section/GetAllSections");
    //}


    this.getPurchaseByBranch = function (branchId) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetAllPurchasesByBranch",
            params: {
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }

    //this.getAllDesignations = function () {
    //    return $http.get("/Designation/GetAllDesignations");
    //}

    this.getPurchaseDetailByPurchase = function (invoiceno) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetPurchaseDetailByPurchase",
            params: {
                invoiceno: JSON.stringify(invoiceno)
            }
        });
        return response;
    }
    this.getPurchaseDetailById = function (purchasedetailid) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetPurchaseDetailById",
            params: {
                purchasedetailid: JSON.stringify(purchasedetailid)
            }
        });
        return response;
    }

    this.getPurchaseByInvoiceNo = function (invoiceno) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/GetPurchaseByInvoiceNo",
            params: {
                invoiceno: JSON.stringify(invoiceno)
            }
        });
        return response;
    }

    //this.getPurchaseDetail = function (purchaseDetailId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/PurchaseDetail/GetPurchaseDetailById",
    //        params: {
    //            purchaseDetailId: JSON.stringify(purchaseDetailId)
    //        }
    //    });
    //    return response;
    //}

    this.updatePurchase = function (purchase) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/UpdatePurchase",
            data: JSON.stringify(purchase),
            dataType: "json"
        });
        return response;
    }

    this.addPurchaseDetail = function (purchaseDetail) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/AddPurchaseDetail",
            data: JSON.stringify(purchaseDetail),
            dataType: "json"
        });
        return response;
    }

    this.deletePurchaseDetail = function (PurchaseDetailId) {
        var response = $http({
            method: "post",
            url: "/PurchaseDetail/DeletePurchaseDetail",
            params: {
                PurchaseDetailId: JSON.stringify(PurchaseDetailId)
            }
        });
        return response;
    }
})