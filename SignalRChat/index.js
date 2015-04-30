"use strict";
$application.controller("index", ["$scope", "chat", function ($scope, chat) {
    $scope.messages = "Connected";

    $scope.click = function () {
        chat.server.send($scope.message);
    };

    chat.client.addMessage = function (message) {
        $scope.$apply(function () {
            $scope.messages = $scope.messages + "\n" + message;
        });
    };
}]);