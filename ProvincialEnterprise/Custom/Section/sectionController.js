app.controller("secCtrl", function ($scope, secService) {

    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = secService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    //$scope.getAllSectionsByCompany = function () {
    //    var companyId = $scope.companyId;
    //    var getSectionData = secService.getAllSections(companyId, null);
    //    getSectionData.then(function (section) {
    //        $scope.sections = section.data;
    //    }, function () {
    //        alert("Error getting record");
    //    });
    //}

    $scope.getAllBranchesByCompany = function() {
        var companyId = $scope.companyId;
        var getSectionData = secService.getAllBranchesByCompany(companyId);
        getSectionData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getAllSections = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getSectionData = secService.getAllSections(companyId, branchId);
        getSectionData.then(function (section) {
            $scope.sections = section.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.editSection = function (section) {
        var getSectionData = secService.getSection(section.SectionId);
        getSectionData.then(function (_section) {
            $scope.section = _section.data;
            $scope.sectionId = section.SectionId;
            $scope.name = section.Name;
            $scope.branchId = section.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateSection = function () {
        Section = {
            Name: $scope.name,
            BranchId: $scope.branchId
        }

        var sectionAction = $scope.Action;
        if (sectionAction == "Update") {
            Section.SectionId = $scope.sectionId;
            var getSectionData = secService.updateSection(Section);
            getSectionData.then(function(msg) {
                $scope.getAllSections();
                alert(msg.data);
            }, function() {
                alert('Error in updating record');
            });
        } else {
            var getSectionData = secService.addSection(Section);
            getSectionData.then(function(msg) {
                $scope.getAllSections();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in add record');
            });
        }
    }

    $scope.deleteSection = function(section) {
        var getSectionData = secService.deleteSection(section.SectionId);
        getSectionData.then(function (msg) {
            $scope.getAllSections();
            alert(msg.data);
            ClearFields();
        }, function() {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
       // $scope.branchId = "";
        $scope.name = "";
        $scope.sectionId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});