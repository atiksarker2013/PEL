app.controller("osCtrl", function ($scope, osService) {

    getAllCompanies();
   
    function getAllCompanies() {
        var getCompanyData = osService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

   $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getSectionData = osService.getAllBranchesByCompany(companyId);
        getSectionData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllSuppliers = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getSupplierData = osService.getSuppliers(companyId, branchId);
        getSupplierData.then(function (supplier) {
            $scope.suppliers = supplier.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAccount = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var mainHeadId = 4;
        var getAccountData = osService.getAccount(companyId, branchId, mainHeadId);
        getAccountData.then(function (account) {
            $scope.accounts = account.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getItems = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getItemData = osService.getItems(companyId, branchId);
        getItemData.then(function (item) {
            $scope.items = item.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getModels = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var itemId = $scope.itemId;
        var getItemData = osService.getModels(companyId, branchId, itemId);
        getItemData.then(function (model) {
            $scope.models = model.data;
        }, function () {
            alert('Error in getting records');
        });
    }
});