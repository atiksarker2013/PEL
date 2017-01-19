app.service("headService", function($http) {

    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
    }

    this.getMainHeadres = function (companyId,branchId,accountTypeId) {
        var response = $http({
            method: "post",
            url: "/MainHead/GetMainHeads",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                accountTypeId: JSON.stringify(accountTypeId)
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

    this.getAccountTypes= function() {
        return $http.get("/AccountType/GetAccountType");
    }

    this.getMainHead = function (mainHeadId) {
        var response = $http({
            method: "post",
            url: "/MainHead/GetMainHeadById",
            params: {
                id: JSON.stringify(mainHeadId)
            }
        });
        return response;
    }

    this.updateMainHead = function (mainHead) {
        var response = $http({
            method: "post",
            url: "/MainHead/UpdateMainHead",
            data: JSON.stringify(mainHead),
            dataType: "json"
        });
        return response;
    }

    this.addMainHead = function (mainHead) {
        var response = $http({
            method: "post",
            url: "/MainHead/AddMainHead",
            data: JSON.stringify(mainHead),
            dataType: "json"
        });
        return response;
    }

    this.deleteMainHead = function (mainHeadId) {
        var response = $http({
            method: "post",
            url: "/MainHead/DeleteMainHead",
            params: {
                id: JSON.stringify(mainHeadId)
            }
        });
        return response;
    }
});