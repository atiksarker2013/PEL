app.service("itemService", function ($http) {

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

    //this.getItems = function () {
    //    return $http.get("/Item/GetAllItems");
    //};

    this.getItem = function (itemId) {
        var response = $http({
            method: "post",
            url: "/Item/GetItemById",
            params: {
                id: JSON.stringify(itemId)
            }
        });
        return response;
    }

    this.updateItem = function (item) {
        var response = $http({
            method: "post",
            url: "/Item/UpdateItem",
            data: JSON.stringify(item),
            dataType: "json"
        });
        return response;
    }

    this.addItem = function (item) {
        var response = $http({
            method: "post",
            url: "/Item/AddItem",
            data: JSON.stringify(item),
            dataType: "json"
        });
        return response;
    }

    this.deleteItem = function (itemId) {
        var response = $http({
            method: "post",
            url: "/Item/DeleteItem",
            params: {
                id: JSON.stringify(itemId)
            }
        });
        return response;
    }
});