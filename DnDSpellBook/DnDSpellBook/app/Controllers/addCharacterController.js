app.controller("addCharacterController", ["$scope", "$http", "$location", function ($scope, $http, $location) {

    $scope.values = [];
    $scope.newCharacterName = "";

    $scope.addCharacter = function () {
        $http.post("/api/character/new", {name:$scope.newCharacterName})
            .then(function (result) {
                console.log("result=", result);
                $location.path("/character");
            });
    };
}]);