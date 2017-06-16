app.controller("spellbookController", ["$scope", "$http", function ($scope, $http) {

    $scope.classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];

    $scope.levels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    console.log("levels", $scope.levels);

    $scope.spells = [];

    $scope.spelldetail = {};

    $scope.selectedCharacter = []

    $scope.getSpells = function (selectedClass, selectedLevel) {

        $http.get(`/api/spells/${selectedClass}/${selectedLevel}`)
            .then(function (result) {
                $scope.spells = result.data;
                console.log("spells",$scope.spells);
                console.log(result);
            });
    };

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


    $scope.addSpellToCharacter = function (selectedCharacter, spelldetail) {
        $http.post("/api/spells/addspelltocharacter", { name: $scope.newCharacterName })
            .then(function (result) {
                console.log("result=", result);
                $location.path("/spellbook");
            });
    };

    $scope.getCharacters = function () {
        $http.get(`/api/characters`)
            .then(function (result) {
                $scope.characters = result.data;
                console.log("characters", $scope.characters);
                console.log(result);
            });
    };

    $scope.getCharacters();

}]);