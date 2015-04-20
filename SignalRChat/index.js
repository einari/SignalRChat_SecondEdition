"use strict";
$application.controller("index", ["$scope", "chat", function ($scope, chat) {
    $scope.messages = "Connected";

    chat.received(function (data) {
        $scope.$apply(function () {
            $scope.messages = $scope.messages + "\n" + data;
        });
        
    });

    $scope.click = function () {
        chat.send($scope.message);
    };
}]);