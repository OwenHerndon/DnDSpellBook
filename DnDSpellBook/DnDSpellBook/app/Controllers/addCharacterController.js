app.controller("addCharacterController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    $scope.values = [];
    $scope.newCharacterName = "";

    $scope.addCharacter = function () {
        $http({
            method: 'POST',
            url: "/api/character/new",
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: { name: $scope.newCharacterName }
        })
            .then(function (result) {
                console.log("result=", result);
                $location.path("/character");
            });
    };
}]);