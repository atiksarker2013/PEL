app.controller("itemCtrl", function ($scope, itemService) {

    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = itemService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = itemService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getItems = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getItemData = itemService.getItems(companyId, branchId);
        getItemData.then(function (item) {
            $scope.items = item.data;
        }, function () {
            alert('Error in getting records');
        });
    }
    

    $scope.editItem = function (item) {
        var getItemData = itemService.getItem(item.ItemId);
        getItemData.then(function (_item) {
            $scope.item = _item.data;
            $scope.itemId = item.ItemId;
            $scope.name = item.ItemName;
            $scope.branchId = item.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateItem = function () {
        var Item = {
            ItemName: $scope.name,
            BranchId: $scope.branchId
        };
        var getItemAction = $scope.Action;

        if (getItemAction == "Update") {
            Item.ItemId = $scope.itemId;
            var getItemData = itemService.updateItem(Item);
            getItemData.then(function (msg) {
                $scope.getItems();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getItemData = itemService.addItem(Item);
            getItemData.then(function (msg) {
                $scope.getItems();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteItem = function (item) {
        var getItemData = itemService.deleteItem(item.ItemId);
        getItemData.then(function (msg) {
            $scope.getItems();
            alert(msg.data);
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.itemId = "";
        $scope.name = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});