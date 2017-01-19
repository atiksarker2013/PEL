app.controller("accCtrl", function($scope, accService) {
    
    //GetAllAccounts();
    //GetAllBranches();
    //GetAllMainHeads();
    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = accService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
        //$scope.mainHeadId = "";
    }

    $scope.getLedgers = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var mainHeadId = $scope.mainHeadId;
        var getLedgerData = accService.getLedgers(companyId, branchId, mainHeadId);
        getLedgerData.then(function (account) {
            $scope.accounts = account.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = accService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getMainHeadsByBranch = function () {
        var branchId = $scope.branchId;
        var getMainHeadData = accService.getMainHeadsByBranch(branchId);
        getMainHeadData.then(function (mainHead) {
            $scope.mainHeads = mainHead.data;
        }, function () {
            alert('Error in getting records');
        });
    }
    
    $scope.editAccount = function (account) {
        var getAccountData = accService.getAccount(account.AccountId);
        getAccountData.then(function (_account) {
            $scope.account = _account.data;
            $scope.accountId = account.AccountId;
            $scope.name = account.Name;
            $scope.mainHeadId = account.MainHeadId;
            $scope.branchId = account.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateAccount = function () {
        var Account = {
            AccountName: $scope.name,
            MainHeadId: $scope.mainHeadId,
            BranchId: $scope.branchId
        };
        var getAccountAction = $scope.Action;

        if (getAccountAction == "Update") {
            Account.AccountId = $scope.accountId;
            var getAccountData = accService.updateAccount(Account);
            getAccountData.then(function (msg) {
                $scope.getLedgers();
                alert(msg.data);
                
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getAccountData = accService.addAccount(Account);
            getAccountData.then(function (msg) {
                $scope.getLedgers();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteAccount = function (account) {
        var getAccountData = accService.deleteAccount(account.AccountId);
        getAccountData.then(function (msg) {
            $scope.getLedgers();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
       // $scope.accountId = "";
        $scope.name = "";
       // $scope.mainHeadId = "";
       // $scope.branchId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});