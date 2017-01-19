app.service("modelService", function ($http) {

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

    this.getItemsByBranch = function (branchId) {
        var response = $http({
            method: "post",
            url: "/Item/GetItemsByBranch",
            params: {
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
    }
    //this.getItems = function () {
    //    return $http.get("/Item/GetAllItems");
    //};
    //this.getModels = function () {
    //    return $http.get("/Model/GetAllModels");
    //};

    this.getModel = function (modelId) {
        var response = $http({
            method: "post",
            url: "/Model/GetModelById",
            params: {
                id: JSON.stringify(modelId)
            }
        });
        return response;
    }

    this.updateModel = function (model) {
        var response = $http({
            method: "post",
            url: "/Model/UpdateModel",
            data: JSON.stringify(model),
            dataType: "json"
        });
        return response;
    }

    this.addModel = function (model) {
        var response = $http({
            method: "post",
            url: "/Model/AddModel",
            data: JSON.stringify(model),
            dataType: "json"
        });
        return response;
    }

    this.deleteModel = function (modelId) {
        var response = $http({
            method: "post",
            url: "/Model/DeleteModel",
            params: {
                id: JSON.stringify(modelId)
            }
        });
        return response;
    }
});