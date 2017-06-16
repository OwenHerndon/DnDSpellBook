app.controller("characterController", ["$scope", "$http", function ($scope, $http) {

    $scope.characters = [];

    $scope.charactersSpells = [];

    $scope.spelldetail = {};

    //gets list of characters
    $scope.getCharacters = function () {
        $http.get(`/api/characters`)
            .then(function (result) {
                $scope.characters = result.data;
                console.log("characters", $scope.characters);
                console.log(result);
            });
    };

    //get character spells?
    $scope.getCharactersSpells = function () {
        $http.get(`/api/characters/spells`)
            .then(function (result) {
                $scope.characters = result.data;
                console.log("spells", $scope.characters);
                console.log(result);
            });
    };

    //gets spell detail
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