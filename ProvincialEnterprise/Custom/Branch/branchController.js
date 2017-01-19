app.controller("branchCtrl", function ($scope, branchService) {

    getAllCompanies();

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getSectionData = branchService.getAllBranchesByCompany(companyId);
        getSectionData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    function getAllCompanies() {
        var getBranchData = branchService.getCompanies();
        getBranchData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.editBranch = function (branch) {
        var getBranchData = branchService.getBranch(branch.BranchId);
        getBranchData.then(function (_branch) {

            $scope.branch = _branch.data;
            $scope.branchId = branch.BranchId;
            $scope.name = branch.Name;
            $scope.address = branch.Address;
            $scope.contact = branch.Contact;
            $scope.web = branch.Web;
            $scope.email = branch.Email;
            $scope.companyId = branch.CompanyId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateBranch = function () {
        var Branch = {
            Name: $scope.name,
            Address: $scope.address,
            Contact: $scope.contact,
            Web: $scope.web,
            Email: $scope.email,
            CompanyId: $scope.companyId
        };
        var getBranchAction = $scope.Action;
        if (getBranchAction == "Update") {
            Branch.BranchId = $scope.branchId;
            var getBranchData = branchService.updateBranch(Branch);
            getBranchData.then(function(msg) {
                $scope.getAllBranchesByCompany();
                alert(msg.data);
            }, function() {
                alert('Error in updating record');
            });
        } else {
            var getBranchData = branchService.addBranch(Branch);
            getBranchData.then(function(msg) {
                $scope.getAllBranchesByCompany();
                alert(msg.data);
                ClearFields();
            },function() {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteBranch = function(branch) {
        var getBranchData = branchService.deleteBranch(branch.BranchId);
        getBranchData.then(function(msg) {
            $scope.getAllBranchesByCompany();
            alert(msg.data);
            ClearFields();
        }, function() {
            alert('Error in deleting record');
        });
    }

    $scope.AddBranchDiv = function () {
        ClearFields();
    }

    function ClearFields() {
        $scope.branchId = "";
        $scope.name = "";
        $scope.address = "";
        $scope.contact = "";
        $scope.web = "";
        $scope.email = "";
        $scope.Action = "Add";
       // $scope.companyId = "";
        //getAllCompanies();
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});