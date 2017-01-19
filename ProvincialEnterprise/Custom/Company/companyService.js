app.service("compService",function($http) {

    this.getCompanies = function () {
        return $http.get("/Company/GetAllCompanies");
    };

    // get Book by bookId
    this.getCompany = function (companyId) {
        var response = $http({
            method: "post",
            url: "/Company/GetCompanyById",
            params: {
                id: JSON.stringify(companyId)
            }
        });
        return response;
    }

    // Update Book 
    this.updateCompany = function (company) {
        var response = $http({
            method: "post",
            url: "/Company/UpdateCompany",
            data: JSON.stringify(company),
            dataType: "json"
        });
        return response;
    }

    // Add Book
    this.addCompany = function (company) {
        var response = $http({
            method: "post",
            url: "/Company/AddCompany",
            data: JSON.stringify(company),
            dataType: "json"
        });
        return response;
    }

    //Delete Book
    this.deleteCompany = function (companyId) {
        var response = $http({
            method: "post",
            url: "/Company/DeleteCompany",
            params: {
                id: JSON.stringify(companyId)
            }
        });
        return response;
    }
})