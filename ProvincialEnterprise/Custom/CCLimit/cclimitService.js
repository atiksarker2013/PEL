app.service("cclimitService", function ($http) {

    //this.getCCLimits = function () {
    //    return $http.get("/CCLimit/GetCCLimits");
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

    this.getCCLimits = function (companyId, branchId, bankId) {
        var response = $http({
            method: "post",
            url: "/CCLimit/GetCCLimits",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                bankId: JSON.stringify(bankId)
            }
        });
        return response;
    }

    this.getBanks = function (companyId, branchId) {
        var response = $http({
            method: "post",
            url: "/CCLimit/GetAllBanks",
            params: {
                companyId: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }

    //this.getBanks = function () {
    //    return $http.get("/CCLimit/GetAllBanks");
    //}

    //this.getCCLimitByBank = function (bankId) {
    //    var response = $http({
    //        method: "post",
    //        url: "/CCLimit/GetAllCCLimitByBank",
    //        params: {               
    //            bankId: JSON.stringify(bankId)
    //        }
    //    });
    //    return response;
    //}

    this.getCCLimitById = function (cclimitId) {
        var response = $http({
            method: "post",
            url: "/CCLimit/GetCCLimitById",
            params: {
                id: JSON.stringify(cclimitId)
            }
        });
        return response;
    }

    //// update
    this.updateCCLimit = function (cclimit) {
        var response = $http({
            method: "post",
            url: "/CCLimit/UpdateCCLimit",
            data: JSON.stringify(cclimit),
            dataType: "json"
        });
        return response;
    }

    // // Add 
    this.addCCLimit = function (cclimit) {
        var response = $http({
            method: "post",
            url: "/CCLimit/AddCCLimit",
            data: JSON.stringify(cclimit),
            dataType: "json"
        });
        return response;
    }

    // //Delete
    this.deleteCCLimit = function (cclimitId) {
        var response = $http({
            method: "post",
            url: "/CCLimit/DeleteCCLimit",
            params: {
                id: JSON.stringify(cclimitId)
            }
        });
        return response;
    }

    //this.datepicker = function () {
    //    return $http.get({
    //        restrict: "A",
    //        require: "ngModel",
    //        link: function (scope, elem, attrs, ngModelCtrl) {
    //            var updateModel = function (dateText) {
    //                scope.$apply(function () {
    //                    ngModelCtrl.$setViewValue(dateText);
    //                });
    //            };
    //            var options = {
    //                dateFormat: "mm/dd/yy",
    //                onSelect: function (dateText) {
    //                    updateModel(dateText);
    //                }
    //            };
    //            elem.datepicker(options);
    //        }
    //    });
    //}
})
