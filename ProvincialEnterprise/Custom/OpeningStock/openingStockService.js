app.service("osService", function ($http) {

    
    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
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

    this.getSuppliers = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/Supplier/GetSuppliers",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    };

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
    };

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
    };

    this.getModels = function (companyId, branchId, itemId) {
        var response = $http({
            method: "post",
            url: "/Model/GetModels",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                itemId: JSON.stringify(itemId)
            }
        });
        return response;
    };

});