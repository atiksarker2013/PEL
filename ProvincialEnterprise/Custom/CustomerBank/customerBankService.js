app.service("cBankService", function($http) {
    
    this.getBanks = function () {
        return $http.get("/CustomerBank/GetAllBanks");
    };

    this.getBank = function (bankId) {
        var response = $http({
            method: "post",
            url: "/CustomerBank/GetBankById",
            params: {
                id: JSON.stringify(bankId)
            }
        });
        return response;
    }

    this.updateBank = function (bank) {
        var response = $http({
            method: "post",
            url: "/CustomerBank/UpdateBank",
            data: JSON.stringify(bank),
            dataType: "json"
        });
        return response;
    }

    this.addBank = function (bank) {
        var response = $http({
            method: "post",
            url: "/CustomerBank/AddBank",
            data: JSON.stringify(bank),
            dataType: "json"
        });
        return response;
    }

    this.deleteBank = function (bankId) {
        var response = $http({
            method: "post",
            url: "/CustomerBank/DeleteBank",
            params: {
                id: JSON.stringify(bankId)
            }
        });
        return response;
    }
});