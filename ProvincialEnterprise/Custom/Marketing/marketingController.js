app.controller("marketingCtrl", function ($scope, marketingService) {

    
    getAllCompanies();

    function getAllCompanies() {
        var getCompanyData = marketingService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = marketingService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getMarketing = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getMarketingData = marketingService.getMarketing(companyId, branchId);
        getMarketingData.then(function (market) {
            $scope.marketingPeoples = market.data;
        }, function () {
            alert('Error in getting records');
        });
    }

   
    $scope.editMarket = function (market) {
        var getMarketingData = marketingService.getMarket(market.MarketId);
        getMarketingData.then(function (_market) {
            $scope.market = _market.data;
            $scope.marketId = market.MarketId;
            $scope.name = market.MarketName;
            $scope.contact = market.Contact;
            $scope.branchId = market.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.AddUpdateMarket = function () {
        var Market = {
            MarketName: $scope.name,
            Contact: $scope.contact,
            BranchId: $scope.branchId
        };
        var getMarketAction = $scope.Action;

        if (getMarketAction == "Update") {
            Market.MarketId = $scope.marketId;
            var getMarketData = marketingService.updateMarket(Market);
            getMarketData.then(function (msg) {
                //GetAllMarketingPeoples();
                $scope.getMarketing();
                alert(msg.data);
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getMarketData = marketingService.addMarket(Market);
            getMarketData.then(function (msg) {
                //GetAllMarketingPeoples();
                $scope.getMarketing();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteMarket = function (market) {
        var getMarketData = marketingService.deleteMarket(market.MarketId);
        getMarketData.then(function (msg) {
            //GetAllMarketingPeoples();
            $scope.getMarketing();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.marketId = "";
        $scope.name = "";
        $scope.contact = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };

});

