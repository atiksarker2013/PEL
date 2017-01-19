app.service("marketingService", function ($http) {

    //this.getMarketingPeoples = function () {
    //    return $http.get("/Market/GetAllPeoples");
    //}

    //this.getBranches = function () {
    //    return $http.get("/Branch/GetAllBranches");
    //}

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

    this.getMarketing = function (companyId,branchId) {
        var response = $http({
            method: "post",
            url: "/Market/GetMarketing",
            params: {
                id: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }

    this.getMarket = function (marketId) {
        var response = $http({
            method: "post",
            url: "/Market/GetMarketingById",
            params: {
                id: JSON.stringify(marketId)
            }
        });
        return response;
    }

    //update
    this.updateMarket = function (market) {
        var response = $http({
            method: "post",
            url: "/Market/UpdateMarketing",
            data: JSON.stringify(market),
            dataType: "json"
        });
        return response;
    }

    // Add 
    this.addMarket = function (market) {
        var response = $http({
            method: "post",
            url: "/Market/AddMarket",
            data: JSON.stringify(market),
            dataType: "json"
        });
        return response;
    }

    //Delete
    this.deleteMarket = function (marketId) {
        var response = $http({
            method: "post",
            url: "/Market/DeleteMarket",
            params: {
                id: JSON.stringify(marketId)
            }
        });
        return response;
    }
});

