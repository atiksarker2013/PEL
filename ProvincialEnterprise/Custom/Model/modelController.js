app.controller("modelCtrl", function ($scope, modelService) {

    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = modelService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
        //$scope.itemId = "";
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = modelService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getItemsByBranch = function () {
        var branchId = $scope.branchId;
        var getItemData = modelService.getItemsByBranch(branchId);
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
        var getModelData = modelService.getModels(companyId, branchId, itemId);
        getModelData.then(function (model) {
            $scope.models = model.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editModel = function (model) {
        var getModelData = modelService.getModel(model.ModelId);
        getModelData.then(function (_model) {
            $scope.model = _model.data;
            $scope.modelId = model.ModelId;
            $scope.itemId = model.ItemId;
            $scope.modelName = model.ModelName;
            $scope.price = model.Price;
            $scope.qty = model.Qty;
            $scope.salePrice = model.SalePrice;
            $scope.reorderQty = model.ReorderQty;
            $scope.isWarranty = model.IsWarranty;
            $scope.avgCost = model.AvgCost;
            $scope.branchId = model.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateModel = function () {
        var Model = {
            ModelId: $scope.modelId,
            ItemId: $scope.itemId,
            ModelName: $scope.modelName,
            Price: $scope.price,
            Qty: $scope.qty,
            SalePrice: $scope.salePrice,
            ReorderQty: $scope.reorderQty,
            IsWarranty: $scope.isWarranty,
            AvgCost: $scope.avgCost,
            BranchId: $scope.branchId
        };
        var getModelAction = $scope.Action;

        if (getModelAction == "Update") {
            Model.ModelId = $scope.modelId;
            var getModelData = modelService.updateModel(Model);
            getModelData.then(function (msg) {
                $scope.getModels();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getModelData = modelService.addModel(Model);
            getModelData.then(function (msg) {
                $scope.getModels();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteModel = function (model) {
        var getModelData = modelService.deleteModel(model.modelId);
        getModelData.then(function (msg) {
            $scope.getModels();
            alert(msg.data);
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.modelId = "";
       // $scope.itemId = "";
        $scope.modelName = "";
        $scope.price = "";
        $scope.qty = "";
        $scope.salePrice = "";
        $scope.reorderQty = "";
        $scope.isWarranty = "";
        $scope.avgCost = "";
        //$scope.branchId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});