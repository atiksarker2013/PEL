app.service("suppService", function ($http) {

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

    //this.getSuppliers = function () {
    //    return $http.get("/Supplier/GetAllSupliers");
    //}

    //this.getBranches = function () {
    //    return $http.get("/Branch/GetAllBranches");
    //}

    this.getSupplier = function (supplierId) {
        var response = $http({
            method: "post",
            url: "/Supplier/GetSupplierById",
            params: {
                id: JSON.stringify(supplierId)
            }
        });
        return response;
    }

    this.updateSupplier = function (supplier) {
        var response = $http({
            method: "post",
            url: "/Supplier/UpdateSuppler",
            data: JSON.stringify(supplier),
            dataType: "json"
        });
        return response;
    }

    this.addSupplier = function (supplier) {
        var response = $http({
            method: "post",
            url: "/Supplier/AddSupplier",
            data: JSON.stringify(supplier),
            dataType: "json"
        });
        return response;
    }

    this.deleteSupplier = function (supplierId) {
        var response = $http({
            method: "post",
            url: "/Supplier/DeleteSupplier",
            params: {
                id: JSON.stringify(supplierId)
            }
        });
        return response;
    }
});