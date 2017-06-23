app.controller("characterController", ["$scope", "$http", function ($scope, $http) {

    $scope.characters = [];

    $scope.charactersSpells = [];

    $scope.selectedCharacter = {};

    $scope.selectedSpell = [];

    $scope.cardDetail = [];
    
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
    $scope.spellDetail = function (characterSpell, $index) {
        spellurl = encodeURIComponent(characterSpell.url);
        console.log("url passed in", spellurl);
        if ($scope.cardDetail[$index] == true) {
            $scope.cardDetail[$index] = false;
        } else {
            $scope.cardDetail[$index] = true;
        }
        $http.get(`/api/spells/?spellurl=${spellurl}`)
           .then(function (result) {
               $scope.charactersSpells[$index].spelldetail = result.data;
               //console.log("spelldetail", characterSpell.spelldetail);
               console.log(result);
           });

    };

    //delete spell
    $scope.deleteSpell = function (spellName, characterId) {
        console.log("Spell to be deleted", spellName);
        console.log("characterID", characterId);
        $http.delete(`/api/character/spell/delete/${spellName}/${characterId}`)
            .then(function () {
                $scope.getCharacterSpells(characterId);
            });
    };

    //deletes character
    $scope.deleteCharacter = function (selectedCharacterId) {
        console.log("SelectedcharId", selectedCharacterId);
        $http.delete(`/api/character/delete/${selectedCharacterId}`)
    };
}]);