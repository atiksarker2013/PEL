app.service("unitService", function ($http) {
    //Get All Unit
    //this.getUnits = function () {
    //    return $http.get("/Unit/GetUnits");
    //}

    this.getCompanies = function () {
        return $http.get("/Branch/GetAllCompanies");
    }

    this.getAllBranchesByCompany = function (comanyId) {
        var response = $http({
            method: "post",
            url: "/Branch/GetAllBranchesByCompany",
            params: {
                id: JSON.stringify(comanyId)
            }
        });
        return response;
    }

    this.getUnits = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/Unit/GetUnits",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    };

    // get Unit by unitId
    this.getUnitById = function (unitId) {
        var response = $http({
            method: "post",
            url: "/Unit/GetUnitById",
            params: {
                id: JSON.stringify(unitId)
            }
        });
        return response;
    }

    // Update Unit 
    this.updateUnit = function (unit) {
        var response = $http({
            method: "post",
            url: "/Unit/UpdateUnit",
            data: JSON.stringify(unit),
            dataType: "json"
        });
        return response;
    }

    // Add Unit
    this.addUnit = function (unit) {
        var response = $http({
            method: "post",
            url: "/Unit/AddUnit",
            data: JSON.stringify(unit),
            dataType: "json"
        });
        return response;
    }

    //Delete Unit
    this.deleteUnit = function (unitId) {
        var response = $http({
            method: "post",
            url: "/Unit/DeleteUnit",
            params: {
                id: JSON.stringify(unitId)
            }
        });
        return response;
    }
});