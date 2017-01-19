app.controller("compCtrl", function ($scope, compService) {

    GetAllCompanies();

    //To Get all book records  
    function GetAllCompanies() {
       // debugger;
        var getCompanyData = compService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert('Error in getting company records');
        });
    }

    $scope.editCompany = function (company) {
        var getCompanyData = compService.getCompany(company.CompanyId);
        getCompanyData.then(function (_company) {
            $scope.company = _company.data;
            $scope.companyId = company.CompanyId;
            $scope.name = company.Name;
            $scope.address = company.Address;
            $scope.contact = company.Contact;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting company records');
        });
    }

    $scope.AddUpdateCompany = function () {
        var Company = {
            Name: $scope.name,
            Address: $scope.address,
            Contact: $scope.contact
        };
        var getCompanyAction = $scope.Action;

        if (getCompanyAction == "Update") {
            Company.CompanyId = $scope.companyId;
            var getCompanyData = compService.updateCompany(Company);
            getCompanyData.then(function (msg) {
                GetAllCompanies();
                alert(msg.data);
                
            }, function () {
                alert('Error in updating company record');
            });
        } else {

            var getCompanyData = compService.addCompany(Company);
            getCompanyData.then(function (msg) {
                GetAllCompanies();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding company record');
            });
        }
    }

    $scope.deleteCompany = function (company) {
        var getCompanyData = compService.deleteCompany(company.CompanyId);
        getCompanyData.then(function (msg) {
            GetAllCompanies();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting company record');
        });
    }

    function ClearFields() {
        $scope.companyId = "";
        $scope.name = "";
        $scope.address = "";
        $scope.contact = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});