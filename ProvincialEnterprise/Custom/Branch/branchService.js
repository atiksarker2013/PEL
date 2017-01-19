app.service("branchService", function ($http) {

    this.getCompanies = function () {
        return $http.get("/Branch/GetAllCompanies");
    }

    this.getAllBranches = function () {
        return $http.get("/Branch/GetAllBranches");
    }

    //this.getDuplicateData = function (companyId, branchId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/Branch/GetAllBranchesByCompany",
    //        params: {
    //            id: JSON.stringify(comanyId)
    //        }
    //    });
    //    return response;
    //}
    this.getAllBranchesByCompany = function (comanyId) {
       // return $http.get("/Branch/GetAllBranchesByCompany");
        var response = $http({
            method: "post",
            url: "/Branch/GetAllBranchesByCompany",
            params: {
                id: JSON.stringify(comanyId)
            }
        });
        return response;
    }

    this.getBranch = function (branchId) {
        var response = $http({
            method: "post",
            url: "/Branch/GetBranchById",
            params: {
                id: JSON.stringify(branchId)
            }
        });
        return response;
    }

    this.updateBranch = function (branch) {
        var response = $http({
            method: "post",
            url: "/Branch/UpdateBranch",
            data: JSON.stringify(branch),
            dataType: "json"
        });
        return response;
    }

    this.addBranch = function (branch) {
        var response = $http({
            method: "post",
            url: "/Branch/AddBranch",
            data: JSON.stringify(branch),
            dataType: "json"
        });
        return response;
    }

    this.deleteBranch = function (branchId) {
        var response = $http({
            method: "post",
            url: "/Branch/DeleteBranch",
            params: {
                id: JSON.stringify(branchId)
            }
        });
        return response;
    }
});