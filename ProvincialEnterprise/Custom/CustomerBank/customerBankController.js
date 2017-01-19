app.controller("cBankCtrl", function($scope, cBankService) {
    
    GetAllBanks();

    function GetAllBanks() {
        var getBankData = cBankService.getBanks();
        getBankData.then(function (bank) {
            $scope.banks = bank.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editBank = function (bank) {
        var getBankData = cBankService.getBank(bank.BankId);
        getBankData.then(function (_bank) {
            $scope.bank = _bank.data;
            $scope.bankId = bank.BankId;
            $scope.name = bank.Name;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateBank = function () {
        var Bank = {
            Name: $scope.name
        };
        var getBankAction = $scope.Action;

        if (getBankAction == "Update") {
            Bank.BankId = $scope.bankId;
            var getBankData = cBankService.updateBank(Bank);
            getBankData.then(function (msg) {
                GetAllBanks();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getBankData = cBankService.addBank(Bank);
            getBankData.then(function (msg) {
                GetAllBanks();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteBank = function (bank) {
        var getBankData = cBankService.deleteBank(bank.BankId);
        getBankData.then(function (msg) {
            alert(msg.data);
            GetAllBanks();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.bankId = "";
        $scope.name = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});