app.controller("unitCtrl", function ($scope, unitService) {

    //GetUnits();

    //To Get all unit records  
    //function GetUnits() {
    //    var getUnitData = unitService.getUnits();
    //    getUnitData.then(function (unit) {
    //        $scope.units = unit.data;
    //    }, function () {
    //        alert('Error in getting unit records');
    //    });
    //}

    getAllCompanies();

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getUnitData = unitService.getAllBranchesByCompany(companyId);
        getUnitData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    function getAllCompanies() {
        var getUnitData = unitService.getCompanies();
        getUnitData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getUnits = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getUnitData = unitService.getUnits(companyId, branchId);
        getUnitData.then(function (unit) {
            $scope.units = unit.data;
        }, function () {
            alert('Error in getting unit records');
        });
    }

    $scope.editUnit = function (unit) {
        var getUnitData = unitService.getUnitById(unit.UnitId);
        getUnitData.then(function (_unit) {
            $scope.unit = _unit.data;
            $scope.unitId = unit.UnitId;
            $scope.unitName = unit.UnitName;
            $scope.branchId = unit.BranchId;
            $scope.name = unit.Name;
            $scope.companyId = unit.CompanyId;
            $scope.name = unit.name;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting unit records');
        });
    }

    $scope.addUpdateUnit = function () {
        var Unit = {
            UnitName: $scope.unitName,
            BranchId: $scope.branchId
        };
        var getUnitAction = $scope.Action;
        if (getUnitAction == "Update") {
            Unit.UnitId = $scope.unitId;
            var getUnitData = unitService.updateUnit(Unit);
            getUnitData.then(function (msg) {
                $scope.getUnits();
                alert(msg.data);
               // ClearFields();
            }, function () {
                alert('Error in updating unit record');
            });
        } else {
            var getUnitData = unitService.addUnit(Unit);
            getUnitData.then(function (msg) {
                $scope.getUnits();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding unit record');
            });
        }
    }

    $scope.deleteUnit = function (unit) {
        var getUnitData = unitService.deleteUnit(unit.UnitId);
        getUnitData.then(function (msg) {
            $scope.getUnits();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting unit record');
        });
    }

    function ClearFields() {
        $scope.unitId = "";
        $scope.unitName = "";
        //$scope.branchId = "";
        //$scope.companyId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    }
});