app.controller("headCtrl", function ($scope, headService) {

    //GetAllMainHeads();
    //GetAllBranches();
    getAllAccountTypes();
    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = headService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getAllMainHeads = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var accountTypeId = $scope.accountTypeId;
        var getHeadData = headService.getMainHeadres(companyId, branchId, accountTypeId);
        getHeadData.then(function (mainHead) {
            $scope.mainHeads = mainHead.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    //function GetAllMainHeads() {
    //    var getHeadData = headService.getMainHeadres();
    //    getHeadData.then(function (mainHead) {
    //        $scope.mainHeads = mainHead.data;
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

    function getAllAccountTypes() {
        var getHeadData = headService.getAccountTypes();
        getHeadData.then(function (accountType) {
            $scope.accountTypes = accountType.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = headService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    
    $scope.editMainHead = function (mainHead) {
        var getHeadData = headService.getMainHead(mainHead.MainHeadId);
        getHeadData.then(function (_mainHead) {
            $scope.mainHead = _mainHead.data;
            $scope.mainHeadId = mainHead.MainHeadId;
            $scope.name = mainHead.Name;
            $scope.accountTypeId = mainHead.AccountTypeId;
            $scope.branchId = mainHead.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateMainHead = function () {
        var MainHead = {
            Name: $scope.name,
            AccountTypeId: $scope.accountTypeId,
            BranchId: $scope.branchId
        };
        var getMainHeadAction = $scope.Action;

        if (getMainHeadAction == "Update") {
            MainHead.MainHeadId = $scope.mainHeadId;
            var getHeadData = headService.updateMainHead(MainHead);
            getHeadData.then(function (msg) {
                $scope.getAllMainHeads();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getHeadData = headService.addMainHead(MainHead);
            getHeadData.then(function (msg) {
                $scope.getAllMainHeads();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteMainHead = function (mainHead) {
        var getHeadData = headService.deleteMainHead(mainHead.MainHeadId);
        getHeadData.then(function (msg) {
            $scope.getAllMainHeads();
            alert(msg.data);
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.mainHeadId = "";
        $scope.name = "";
        //$scope.accountType = "";
        //$scope.branchId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});