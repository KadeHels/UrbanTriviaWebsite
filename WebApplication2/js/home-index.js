//home-index.js
var app = angular.module("myapp", []);

app.controller("homeIndexController", function ($scope, $http) {
    
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