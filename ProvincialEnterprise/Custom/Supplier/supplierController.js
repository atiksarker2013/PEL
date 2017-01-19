app.controller("suppCtrl", function ($scope, suppService) {

    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = suppService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = suppService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getSuppliers = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getCustomerData = suppService.getSuppliers(companyId, branchId);
        getCustomerData.then(function (supplier) {
            $scope.suppliers = supplier.data;
        }, function () {
            alert('Error in getting records');
        });
    }
    
    $scope.editSupplier = function (supplier) {
        var getSupplierData = suppService.getSupplier(supplier.SupplierId);
        getSupplierData.then(function (_supplier) {
            $scope.supplier = _supplier.data;
            $scope.supplierId = supplier.SupplierId;
            $scope.name = supplier.Name;
            $scope.address = supplier.Address;
            $scope.contact = supplier.Contact;
            $scope.fax = supplier.Fax;
            $scope.email = supplier.Email;
            $scope.branchId = supplier.BranchId;
            $scope.ownerName = supplier.OwnerName;
            $scope.supplierCode = supplier.SupplierCode;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateSupplier = function () {
        var Supplier = {
            Name: $scope.name,
            Address: $scope.address,
            Contact: $scope.contact,
            Fax: $scope.fax,
            Email: $scope.email,
            BranchId: $scope.branchId,
            OwnerName: $scope.ownerName,
            SupplierCode: $scope.supplierCode
        }
        var getSupplierAction = $scope.Action;
        if (getSupplierAction == "Update") {
            Supplier.SupplierId = $scope.supplierId;
            var getSupplierData = suppService.updateSupplier(Supplier);
            getSupplierData.then(function (msg) {
                $scope.getSuppliers();
                alert(msg.data);
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getSupplierData = suppService.addSupplier(Supplier);
            getSupplierData.then(function (msg) {
                $scope.getSuppliers();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteSupplier = function (supplier) {
        var getSupplierData = suppService.deleteSupplier(supplier.SupplierId);
        getSupplierData.then(function (msg) {
            $scope.getSuppliers();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.supplierId = "";
        $scope.name = "";
        $scope.address = "";
        $scope.contact = "";
        $scope.fax = "";
        $scope.email = "";
        //$scope.branchId = "";
        $scope.ownerName = "";
        $scope.supplierCode = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});