﻿var app = angular.module("SpellBook", ["ngRoute"]);

app.config([
    "$routeProvider", function ($routeProvider) {
        $routeProvider
            .when("/",
            {
                templateUrl: "app/Partials/Login.html",
                controller: "loginController"
            })
            .when("/spellbook",
            {
                templateUrl: "app/Partials/Spellbook.html",
                controller: "spellbookController"
            })
            .when("/spelldetail",
            {
                templateUrl: "app/Partials/spelldetail.html",
                controller: "spellbookController"
            })
            .when("/character",
            {
                templateUrl: "app/Partials/Character.html",
                controller: "characterController"
            })
            .when("/add",
            {
                templateUrl: "app/Partials/AddCharacter.html",
                controller: "addCharacterController"
            })
            .when("/signup",
            {
                templateUrl: "app/Partials/SignUp.html",
                controller: "signupController"
            });

    }
]);

app.run(["$http", function ($http) {

    var token = sessionStorage.getItem('token');

    if (token)
        $http.defaults.headers.common['Authorization'] = `bearer ${token}`;

}
]);