app.controller("spellbookController", ["$scope", "$http", function ($scope, $http, $rootScope, SpellFactory) {

    $scope.classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];

    $scope.levels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    $scope.spells = [];
    
    $scope.getSpells = function (selectedClass, selectedLevel) {
        SpellFactory.getSpells($rootScope.selectedClass, $rootScope.selectedLevel).then(function (apiSpells) {
            $scope.spells = apiSpells;
            console.log("$scope.spells = ", $scope.spells);
        });
    };


}]);