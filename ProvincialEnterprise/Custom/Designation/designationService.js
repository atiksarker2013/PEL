app.service("desigService", function ($http) {

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

    this.getDesignations = function (companyId,branchId,sectionId) {
        var response = $http({
            method: "post",
            url: "/Designation/GetAllDesignations",
            params: {
                id: JSON.stringify(companyId),
                branchId: JSON.stringify(branchId),
                sectionId: JSON.stringify(sectionId)
            }
        });
        return response;
    }

    //this.getAllSections = function () {
    //    return $http.get("/Section/GetAllSections");
    //}
    

    this.getSectionsByBranch = function (branchId) {
        var response = $http({
            method: "post",
            url: "/Section/GetAllSectionsByBranch",
            params: {
                id: JSON.stringify(branchId)
            }
        });
        return response;
    }

    //this.getAllDesignations = function () {
    //    return $http.get("/Designation/GetAllDesignations");
    //}

    this.getDesignationsBySection = function (sectionId) {
        var response = $http({
            method: "post",
            url: "/Designation/GetDesignationsBySection",
            params: {
                id: JSON.stringify(sectionId)
            }
        });
        return response;
    }

    this.getDesignation = function (designationId) {
        var response = $http({
            method: "post",
            url: "/Designation/GetDesignationById",
            params: {
                id: JSON.stringify(designationId)
            }
        });
        return response;
    }

    this.updateDesignation = function (designation) {
        var response = $http({
            method: "post",
            url: "/Designation/UpdateDesignation",
            data: JSON.stringify(designation),
            dataType: "json"
        });
        return response;
    }

    this.addDesignation = function (designation) {
        var response = $http({
            method: "post",
            url: "/Designation/AddDesignation",
            data: JSON.stringify(designation),
            dataType: "json"
        });
        return response;
    }

    this.deleteDesignation = function (designationId) {
        var response = $http({
            method: "post",
            url: "/Designation/DeleteDesignation",
            params: {
                id: JSON.stringify(designationId)
            }
        });
        return response;
    }
});