app.controller("cclimitCtrl", function ($scope, cclimitService) {

    //getAllBanks();
    getAllCompanies();

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getCCLimitData = cclimitService.getAllBranchesByCompany(companyId);
        getCCLimitData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    function getAllCompanies() {
        var getCCLimitData = cclimitService.getCompanies();
        getCCLimitData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getCCLimits = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var bankId = $scope.bankId;
        var getCCLimitData = cclimitService.getCCLimits(companyId, branchId, bankId);
        getCCLimitData.then(function (cclimit) {
            $scope.cclimits = cclimit.data;
        }, function () {
            alert('Error in getting cclimit records');
        });
    }

    //$scope.getCCLimitByBank = function () {
    //    var bankId = $scope.bankId;
    //    var getCCLimitData = cclimitService.getCCLimitByBank(bankId);
    //    getCCLimitData.then(function (cclimit) {
    //        $scope.ccLimits = cclimit.data;
    //    }, function () {
    //        alert('Error in getting records');
    //    });
    //}

    $scope.getBanks = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getBankData = cclimitService.getBanks(companyId, branchId);
        getBankData.then(function (bank) {
            $scope.banks = bank.data;
        }, function () {
            alert('Error in getting banks records');
        });
    }

    //function getAllBanks() {
    //    var getCCLimitData = cclimitService.getBanks();
    //    getCCLimitData.then(function (bank) {
    //        $scope.banks = bank.data;
    //    }, function () {
    //        alert("Error getting record");
    //    });
    //}

    $scope.editCCLimit = function (cclimit) {
        var getCCLimitData = cclimitService.getCCLimitById(cclimit.Id);
        getCCLimitData.then(function (_cclimit) {
            $scope.cclimit = _cclimit.data;
            $scope.id = cclimit.Id;
            $scope.bankId = cclimit.BankId;
            $scope.bankName = cclimit.BankName
            $scope.limitAmount = cclimit.LimitAmount;
            $scope.entryDate = cclimit.EntryDate;
            $scope.branchId = cclimit.BranchId;
            $scope.branchName = cclimit.BranchName;
            $scope.companyId= cclimit.CompanyId;
            $scope.companyName = cclimit.CompanyName;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateCCLimit = function () {
        var CCLimit = {
            BankId: $scope.bankId,
            LimitAmount: $scope.limitAmount,
            EntryDate: $scope.entryDate,
            BranchId: $scope.branchId          
        };
        var getCCLimitAction = $scope.Action;
        if (getCCLimitAction == "Update") {
            CCLimit.Id = $scope.id;
            var getCCLimithData = cclimitService.updateCCLimit(CCLimit);
            getCCLimithData.then(function (msg) {
                $scope.getCCLimits();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getCCLimithData = cclimitService.addCCLimit(CCLimit);
            getCCLimithData.then(function (msg) {
                $scope.getCCLimits();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteCCLimit = function (cclimit) {
        var getCCLimitData = cclimitService.deleteCCLimit(cclimit.Id);
        getCCLimitData.then(function (msg) {
            $scope.getCCLimits();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.id = "";
        //$scope.branchId = "";
        $scope.limitAmount = "";
        $scope.entryDate = "";
       // $scope.bankId = "";
       // $scope.companyId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    }

    //$scope.startingDay = 1;
    //$scope.showWeeks = false;

    //cclimitService.datepickerPopup = "MM/dd/yyyy";
    //cclimitService.currentText = "Now";
    //cclimitService.clearText = "Erase";
    //cclimitService.closeText = "Close";

    //$scope.entryDate = new Date();
    //$scope.opened = {
    //    start: false,
    //    end: false
    //};
})

