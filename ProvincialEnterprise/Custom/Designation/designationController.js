app.controller("desigCtrl", function($scope, desigService) {

    //getAllDesignations();
    //getAllSections();

    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = desigService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
        $scope.sectionId = null;
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = desigService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllDesignations = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var sectionId = $scope.sectionId;
        var getDesignationData = desigService.getDesignations(companyId, branchId, sectionId);
        getDesignationData.then(function (desingnation) {
            $scope.designations = desingnation.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllSectionsByBranch = function () {
        var branchId = $scope.branchId;
        var getSectionData = desigService.getSectionsByBranch(branchId);
        getSectionData.then(function (section) {
            $scope.sections = section.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getDesignationsBySection = function () {
        var sectionId = $scope.sectionId;
        var getDesignationData = desigService.getDesignationsBySection(sectionId);
        getDesignationData.then(function (desingnation) {
            $scope.designations = desingnation.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.editDesignation = function (desingnation) {
        var getDesignationData = desigService.getDesignation(desingnation.DesignationId);

        getDesignationData.then(function (_desingnation) {
            $scope.desingnation = _desingnation.data;
            $scope.designationId = desingnation.DesignationId;
            $scope.name = desingnation.Name;
            $scope.sectionId = desingnation.SectionId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateDesignation = function () {
        Designation = {
            Name: $scope.name,
            SectionId: $scope.sectionId
        }

        var designationAction = $scope.Action;
        if (designationAction == "Update") {
            Designation.DesignationId = $scope.designationId;
            var getDesignationData = desigService.updateDesignation(Designation);
            getDesignationData.then(function (msg) {
                $scope.getAllDesignations();
                alert(msg.data);
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getDesignationData = desigService.addDesignation(Designation);
            getDesignationData.then(function (msg) {
                $scope.getAllDesignations();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in add record');
            });
        }
    }

    $scope.deleteDesignation = function (designation) {
        var getDesignationData = desigService.deleteDesignation(designation.DesignationId);
        getDesignationData.then(function (msg) {
            $scope.getAllDesignations();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.designationId = "";
        $scope.name = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});