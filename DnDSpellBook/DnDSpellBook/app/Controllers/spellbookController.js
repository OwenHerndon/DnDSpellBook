app.controller("spellbookController", ["$scope", '$http', '$rootScope', 'SpellFactory', function ($scope, $http, $rootScope, SpellFactory) {

    $scope.classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];

    $scope.levels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
    console.log("levels",$scope.levels);

    $scope.SpellFactory = SpellFactory;

    $scope.spells = [];
    
    getSpells();

    getSpells = function (selectedClass, selectedLevel) {
        console.log("class",selectedClass);
        console.log("level",selectedLevel);
        
        SpellFactory.getSpellsFromAPI(selectedClass, selectedLevel).then(function (apiSpells) {
            
            $scope.spells = apiSpells;
            console.log("$scope.spells = ", $scope.spells);
        });
    };


}]);