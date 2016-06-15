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
    $routeProvider.when("/addWord", {
        controller: "addWordController",
        templateUrl: "Templates/addWordView.html"
    });

    $routeProvider.otherwise({ redirectTO: "/" });
});

module.factory("dataService", function ($http, $q) {
    var _words = [];
    var _isInit = false;

    var _isReady = function () {
        return _isInit;
    };

    var _getWords = function () {
        
        var deferred = $q.defer();

        $http.get("/api/words")
            .then(function (result) {
                // success
                angular.copy(result.data, _words);
                _isInit = true;
                deferred.resolve();
            },
            function () {
                // error
                deferred.reject();
            })
        return deferred.promise;
    };

    var _addWord = function (newWord) {
        var deferred = $q.defer();

        $http.post("/api/words", newWord)
        .then(function (result) {
            //success
            var newlyCreatedWord = result.data;
            //insert at the beginning of the list
            _words.splice(0, 0, newlyCreatedWord);
            deferred.resolve(newlyCreatedWord);
        },
        function () {
            //error
            deferred.reject();
        });

        return deferred.promise;
    };

    return {
        words: _words,
        getWords: _getWords,
        addWord: _addWord,
        isReady: _isReady
    };
})

module.controller("addWordController", function ($scope, $http, $window,  dataService) {
    $scope.isBusy = false;
    $scope.newWord = {};

    $scope.save = function () {
        $scope.isBusy = true;
        dataService.addWord($scope.newWord)
        .then(function () {
            //success
            $window.location = "#/";
        }, function () {
            //error
            alert("Could not add the word");
        })
        .then(function () {
            $scope.isBusy = false;
        })
    };

    

});

module.controller("wordListController", function ($scope, $http, dataService) {
    $scope.isBusy = false;
    $scope.data = dataService;
    

    if (dataService.isReady() == false) {
        $scope.isBusy = true;
        dataService.getWords()
            .then(function () {
                //success
            },
            function () {
                //error
                alert("Could not load Words");
            })
        .then(function () {
            $scope.isBusy = false;
        });
    }
});

module.controller("wordsController", function ($scope, $http, dataService) {
    $scope.isBusy = false;
    $scope.data = dataService;

    if (dataService.isReady() == false) {
        $scope.isBusy = true;

        dataService.getWords()
        .then(function (result) {
            // success      
        },
        function () {
            // error
            alert("Could not load words");
        })
        .then(function () {
            $scope.isBusy = false;
        });
    }
});