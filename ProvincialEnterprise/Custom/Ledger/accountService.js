app.service("accService", function($http) {

    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
    }

    this.getLedgers = function (companyId, branchId, mainHeadId) {
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

    //this.getBranches = function () {
    //    return $http.get("/Ledger/GetAllBranches");
    //}

    //this.getMainHeads = function () {
    //    return $http.get("/MainHead/GetAllMainHeads");
    //}

    this.getMainHeadsByBranch = function (branchId) {
        var response = $http({
            method: "post",
            url: "/MainHead/GetMainHeadsByBranch",
            params: {
                id: JSON.stringify(branchId)
            }
        });
        return response;
    }

    this.getAccount = function (accountId) {
        var response = $http({
            method: "post",
            url: "/Ledger/GetAccountById",
            params: {
                id: JSON.stringify(accountId)
            }
        });
        return response;
    }

    this.updateAccount = function (account) {
        var response = $http({
            method: "post",
            url: "/Ledger/UpdateAccount",
            data: JSON.stringify(account),
            dataType: "json"
        });
        return response;
    }

    this.addAccount = function (account) {
        var response = $http({
            method: "post",
            url: "/Ledger/AddAccount",
            data: JSON.stringify(account),
            dataType: "json"
        });
        return response;
    }

    this.deleteAccount = function (accountId) {
        var response = $http({
            method: "post",
            url: "/Ledger/DeleteAccount",
            params: {
                id: JSON.stringify(accountId)
            }
        });
        return response;
    }
});