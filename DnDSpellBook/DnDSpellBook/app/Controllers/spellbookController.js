﻿app.controller("spellbookController", ["$scope", "$http", function ($scope, $http) {

    $scope.classes = ["Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard"];

    $scope.levels = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];

    console.log("levels", $scope.levels);

    $scope.spells = [];

    $scope.spelldetail = {};

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

}]);