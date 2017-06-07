app.controller("spellbookController", ["$scope", "$http", function ($scope, $http) {

    $scope.classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];

    $scope.levels = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9];


}]);