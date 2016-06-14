//home-index.js
var module = angular.module("homeIndex", ['ngRoute']);

module.config(function ($routeProvider){
    $routeProvider.when("/", {
        controller: "wordsController",
        templateUrl: "/Templates/wordsView.html"
    });
    $routeProvider.when("/wordList", {
        controller: "wordListController",
        templateUrl: "Templates/wordListView.html"
    });

    $routeProvider.otherwise({ redirectTO: "/" });
});
module.controller("wordListController", function ($scope, $http) {
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("../api/words")
    .then(function (result) {
        // success
        angular.copy(result.data, $scope.data);
    },
    function () {
        // error
        alert("could not load words");
    })
    .then(function () {
        $scope.isBusy = false;
    });
});

module.controller("wordsController", function ($scope, $http) {
    
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/api/words")
    .then(function (result) {
        // success
        angular.copy(result.data, $scope.data);      
    },
    function () {
        // error
        alert("could not load words");
    })
    .then(function () {
        $scope.isBusy = false;
    });
});