app.controller("characterController", ["$scope", "$http", function ($scope, $http) {

    $scope.characters = ["Yarrick"];

    //$scope.getCharacters();

    $scope.getCharacters = function () {

        $http.get(`/api/characters`)
            .then(function (result) {
                $scope.characters = result.data;
                console.log("spells", $scope.characters);
                console.log(result);
            });
    };

    //get character spells?

    $scope.spellDetail = function (spellurl) {

        spellurl = encodeURIComponent(spellurl);
        console.log("url passed in", spellurl);
        $http.get(`/api/spells/?spellurl=${spellurl}`)
           .then(function (result) {
               $scope.spelldetail = result.data;
               console.log("spelldetail", $scope.spelldetail);
               console.log(result);
           });

    };

}]);