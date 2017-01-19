app.controller("bankCtrl", function($scope, bankService) {
    
    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = bankService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = bankService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getBanks = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getBankData = bankService.getBanks(companyId, branchId);
        getBankData.then(function (bank) {
            $scope.banks = bank.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editBank = function (bank) {
        var getBankData = bankService.getBank(bank.BankId);
        getBankData.then(function (_bank) {
            $scope.bank = _bank.data;
            $scope.bankId = bank.BankId;
            $scope.name = bank.BankName;
            $scope.branch = bank.Branch;
            $scope.accountNo = bank.AccountNo;
            $scope.opening = bank.Opening;
            $scope.branchId = bank.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateBank = function () {
        var Bank = {
            BankName: $scope.name,
            Branch: $scope.branch,
            AccountNo: $scope.accountNo,
            Opening: $scope.opening,
            BranchId: $scope.branchId
        };
        var getBankAction = $scope.Action;

        if (getBankAction == "Update") {
            Bank.BankId = $scope.bankId;
            var getBankData = bankService.updateBank(Bank);
            getBankData.then(function (msg) {
                $scope.getBanks();
                alert(msg.data);
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getBankData = bankService.addBank(Bank);
            getBankData.then(function (msg) {
                $scope.getBanks();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteBank = function (bank) {
        var getBankData = bankService.deleteBank(bank.BankId);
        getBankData.then(function (msg) {
            $scope.getBanks();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.bankId = "";
        $scope.name = "";
        $scope.branch = "";
        $scope.accountNo = "";
        $scope.opening = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});