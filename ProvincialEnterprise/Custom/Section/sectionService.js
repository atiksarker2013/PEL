app.service("secService", function($http) {

    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
    }

    this.getAllBranchesByCompany = function (companyId) {
        //return $http.get("/Branch/GetAllBranches");
        var response = $http({
            method: "post",
            url: "/Branch/GetAllBranchesByCompany",
            params: {
                id: JSON.stringify(companyId)
            }
        });
        return response;
    }

    //this.getAllSections = function () {
    //    return $http.get("/Section/GetAllSections");
    //}

    this.getAllSections = function (companyId,branchId) {
        var response = $http({
            method: "post",
            url: "/Section/GetAllSections",
            params: {
                id: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId)
            }
        });
        return response;
    }

    this.getSection = function(sectionId) {
        var response = $http({
            method: "post",
            url: "/Section/GetSectionById",
            params: {
                id: JSON.stringify(sectionId)
            }
        });
        return response;
    }

    this.updateSection = function(section) {
        var response = $http({
            method: "post",
            url: "/Section/UpdateSection",
            data: JSON.stringify(section),
            dataType: "json"
        });
        return response;
    }

    this.addSection = function(section) {
        var response = $http({
            method: "post",
            url: "/Section/AddSection",
            data: JSON.stringify(section),
            dataType: "json"
        });
        return response;
    }

    this.deleteSection = function(sectionId) {
        var response = $http({
            method: "post",
            url: "/Section/DeleteSection",
            params: {
                id: JSON.stringify(sectionId)
            }
        });
        return response;
    }
});