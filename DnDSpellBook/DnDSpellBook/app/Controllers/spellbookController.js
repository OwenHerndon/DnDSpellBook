app.controller("spellbookController", ["$scope", "$http", function ($scope, $http) {

    $scope.classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];

    $scope.levels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    console.log("levels", $scope.levels);

    $scope.spells = [];

    $scope.spelldetail = {};

    $scope.selectedCharacter = [];

    $scope.getSpells = function (selectedClass, selectedLevel) {

        $http.get(`/api/spells/${selectedClass}/${selectedLevel}`)
            .then(function (result) {
                $scope.spells = result.data;
                console.log("spells",$scope.spells);
                console.log(result);
            });
    };

    $scope.spellDetail = function (spell) {
        
        spellurl = encodeURIComponent(spell.url);
        console.log("url passed in", spellurl);
        $http.get(`/api/spells/?spellurl=${spellurl}`)
           .then(function (result) {
               spell.spelldetail = result.data;
               console.log("spelldetail", $scope.spelldetail);
               console.log(result);
           });

    };


    $scope.addSpellToCharacter = function (selectedCharacter, spelldetail) {
        console.log("Selected character Id to DB", selectedCharacter);
        console.log("Spell object to be added to DB", spelldetail);
        $http.post(`/api/spells/addspelltocharacter/${selectedCharacter}`, 
            {
                _id : spelldetail._id,
                index : spelldetail.index,
                name : spelldetail.name,
                desc : spelldetail.desc,
                page : spelldetail.page,
                range : spelldetail.range,
                components : spelldetail.components,
                material : spelldetail.material,
                ritual : spelldetail.ritual,
                duration : spelldetail.duration,
                concentration : spelldetail.concentration,
                casting_time : spelldetail.casting_time,
                level : spelldetail.level,
                school : spelldetail.school,
                classes : spelldetail.classes,
                subclasses : spelldetail.subclasses,
                url : spelldetail.url
            }).then(function (result) {
                console.log("spelladded", result);
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