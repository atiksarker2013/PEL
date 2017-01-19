app.controller("customerCtrl", function ($scope, customerService) {

    getAllCompanies();
    getBanks();

    function getAllCompanies() {
        var getCompanyData = customerService.getCompanies();
        getCompanyData.then(function (company) {
            $scope.companies = company.data;
        }, function () {
            alert("Error getting record");
        });
    }

    $scope.getAllBranchesByCompany = function () {
        var companyId = $scope.companyId;
        var getBranchData = customerService.getAllBranchesByCompany(companyId);
        getBranchData.then(function (branch) {
            $scope.branches = branch.data;
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.getCustomers = function () {
        var companyId = $scope.companyId;
        var branchId = $scope.branchId;
        var getCustomerData = customerService.getCustomers(companyId, branchId);
        getCustomerData.then(function (customer) {
            $scope.customers = customer.data;
        }, function () {
            alert('Error in getting records');
        });
    }
    //getAllCustomers();
    //GetAllBranches();
    //GetAllMarketingPeoples();
    //GetAllBanks();

    function getBanks() {
        var getCustomerData = customerService.getBanks();
        getCustomerData.then(function (bank) {
            $scope.banks = bank.data;
        }, function () {
            alert('Error in getting bank records');
        });
    }

    $scope.getMarketingPeoplesByBranch = function () {
        var branchId = $scope.branchId;
        var getCustomerData = customerService.getMarketingPeoplesByBranch(branchId);
        getCustomerData.then(function (marketing) {
            $scope.marketingPeoples = marketing.data;
        }, function () {
            alert("Error in getting marketing data");
        });
    }

    $scope.editCustomer = function (customer) {
        var getCustomerData = customerService.getCustomer(customer.CustomerId);
        getCustomerData.then(function (_customer) {
            $scope.customer = _customer.data;
            $scope.customerId = customer.CustomerId;
            $scope.name = customer.CustomerName;
            $scope.marketId = customer.MarketId;
            $scope.address = customer.Address;
            $scope.ownerName = customer.OwnerName;
            $scope.telephone = customer.Telephone;
            $scope.email = customer.EmailId;
            $scope.nationalId = customer.NID;
            $scope.tradeLicense = customer.TradeLicense;
            $scope.checkNo = customer.CheckNo;
            $scope.checkAmount = customer.CheckAmount;
            $scope.bankId = customer.BankId;
            $scope.companyCode = customer.CompanyCode;
            $scope.branchId = customer.BranchId;
            $scope.Action = "Update";
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.addUpdateCustomer = function () {
        var Customer = {
            CustomerId: $scope.customerId,
            CustomerName: $scope.name,
            MarketId: $scope.marketId,
            Address: $scope.address,
            OwnerName: $scope.ownerName,
            Telephone: $scope.telephone,
            EmailId: $scope.email,
            NID: $scope.nationalId,
            TradeLicense: $scope.tradeLicense,
            CheckNo: $scope.checkNo,
            CheckAmount: $scope.checkAmount,
            BankId: $scope.bankId,
            CompanyCode: $scope.companyCode,
            BranchId: $scope.branchId
        }
        var getCustomerAction = $scope.Action;
        if (getCustomerAction == "Update") {
            Customer.CustomerId = $scope.customerId;
            var getCustomerData = customerService.updateCustomer(Customer);
            getCustomerData.then(function (msg) {
                $scope.getCustomers();
                alert(msg.data);
            }, function () {
                alert('Error in updating record');
            });
        } else {
            var getCustomerData = customerService.addCustomer(Customer);
            getCustomerData.then(function (msg) {
                $scope.getCustomers();
                alert(msg.data);
                ClearFields();
            }, function () {
                alert('Error in adding record');
            });
        }
    }

    $scope.deleteCustomer = function (customer) {
        var getCustomerData = customerService.deleteCustomer(customer.CustomerId);
        getCustomerData.then(function (msg) {
            $scope.getCustomers();
            alert(msg.data);
            ClearFields();
        }, function () {
            alert('Error in deleting record');
        });
    }

    function ClearFields() {
        $scope.customerId = "";
        $scope.name = "";
        //$scope.marketId = "";
        $scope.address = "";
        $scope.ownerName = "";
        $scope.telephone = "";
        $scope.email = "";
        $scope.nationalId = "";
        $scope.tradeLicense = "";
        $scope.checkNo = "";
        $scope.checkAmount = "";
        //$scope.bankId = "";
        $scope.companyCode = "";
        //$scope.branchId = "";
        $scope.Action = "Add";
    }

    $scope.Cancel = function () {
        ClearFields();
    };
});