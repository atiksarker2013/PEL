app.service("bankService", function($http) {
    
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

    this.getBanks = function (companyId, branchId) {
        //return $http.get("/Ledger/GetAllAccounts");
        var response = $http({
            method: "post",
            url: "/Bank/GetBanks",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    };

    //this.getBranches = function () {
    //    return $http.get("/Bank/GetAllBranches");
    //}

    //this.getBanks = function () {
    //    return $http.get("/Bank/GetAllBanks");
    //}

    this.getBank = function (bankId) {
        var response = $http({
            method: "post",
            url: "/Bank/GetBankById",
            params: {
                id: JSON.stringify(bankId)
            }
        });
        return response;
    }

    this.updateBank = function (bank) {
        var response = $http({
            method: "post",
            url: "/Bank/UpdateBank",
            data: JSON.stringify(bank),
            dataType: "json"
        });
        return response;
    }

    this.addBank = function (bank) {
        var response = $http({
            method: "post",
            url: "/Bank/AddBank",
            data: JSON.stringify(bank),
            dataType: "json"
        });
        return response;
    }

    this.deleteBank = function (bankId) {
        var response = $http({
            method: "post",
            url: "/Bank/DeleteBank",
            params: {
                id: JSON.stringify(bankId)
            }
        });
        return response;
    }
});