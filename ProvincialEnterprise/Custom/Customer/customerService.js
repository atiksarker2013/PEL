app.service("customerService", function ($http) {

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

    this.getCustomers = function (companyId, branchId) {
        //return $http.get("/Ledger/GetAllAccounts");
        var response = $http({
            method: "post",
            url: "/Customer/GetCustomers",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    };

    //this.getBranches = function () {
    //    return $http.get("/Branch/GetAllBranches");
    //}

    this.getMarketingPeoplesByBranch = function (branchId) {
        //return $http.get("/Market/GetPeoplesByBranch");
        var response = $http({
            method: "post",
            url: "/Market/GetPeoplesByBranch",
            params: {
                id: JSON.stringify(branchId)
            }
        });
        return response;
    }

    this.getBanks = function () {
        return $http.get("/CustomerBank/GetAllBanks");
    }

    //this.getCustomers = function () {
    //    return $http.get("/Customer/GetAllCustomers");
    //}

    this.getCustomer = function (customerId) {
        var response = $http({
            method: "post",
            url: "/Customer/GetCustomerById",
            params: {
                id: JSON.stringify(customerId)
            }
        });
        return response;
    }

    this.updateCustomer = function (customer) {
        var response = $http({
            method: "post",
            url: "/Customer/UpdateCustomer",
            data: JSON.stringify(customer),
            dataType: "json"
        });
        return response;
    }

    this.addCustomer = function (customer) {
        var response = $http({
            method: "post",
            url: "/Customer/AddCustomer",
            data: JSON.stringify(customer),
            dataType: "json"
        });
        return response;
    }

    this.deleteCustomer = function (customerId) {
        var response = $http({
            method: "post",
            url: "/Customer/DeleteCustomer",
            params: {
                id: JSON.stringify(customerId)
            }
        });
        return response;
    }
});