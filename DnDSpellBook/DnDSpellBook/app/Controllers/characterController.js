app.controller("characterController", ["$scope", "$http", function ($scope, $http) {

    $scope.characters = [];

    $scope.charactersSpells = [];

    $scope.spelldetail = {};

    $scope.selectedCharacter = {};

    $scope.selectedSpell = [];

   
    
    //gets list of characters
    $scope.getCharacters = function () {
        $http.get(`/api/characters`)
            .then(function (result) {
                $scope.characters = result.data;
                console.log("characters", $scope.characters);
                console.log(result);
            });
    };

    $scope.getCharacters();

    //get character spells
    $scope.getCharacterSpells = function (selectedCharacterId) {
        console.log(selectedCharacterId);
        $http.get(`/api/characters/spells/${selectedCharacterId}`)
            .then(function (result) {
                $scope.charactersSpells = result.data;
                console.log("spells returned", $scope.charactersSpells);
                console.log(result);
            });
    };

    //gets spell detail
    $scope.spellDetail = function (characterSpell) {
        spellurl = encodeURIComponent(characterSpell.url);
        console.log("url passed in", spellurl);
        $http.get(`/api/spells/?spellurl=${spellurl}`)
           .then(function (result) {
               characterSpell.spelldetail = result.data;
               console.log("spelldetail", characterSpell.spelldetail);
               console.log(result);
           });

    };

    //delete spell
    $scope.deleteSpell = function (characterSpell) {
        console.log("Spell Id to be deleted", characterSpell);
    };

    //deletes character
    $scope.deleteCharacter = function (selectedCharacterId) {
        console.log("SelectedcharId", selectedCharacterId);
        $http.delete(`/api/character/delete/${selectedCharacterId}`);
    };
}]);