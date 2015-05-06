"use strict";
$application.controller("index", ["$scope", "chat", "$rootScope", function ($scope, chat, $rootScope) {
    var currentChatRoom = "Lobby";

    $scope.messages = "Connected";

    $scope.click = function () {
        chat.server.send(currentChatRoom, $scope.message);
    };

    $rootScope.$on("chatRoomChanged", function (args, room) {
        currentChatRoom = room;
    });

    chat.client(function (client) {
        client.addMessage = function (message) {
            $scope.$apply(function () {
                $scope.messages = $scope.messages + "\n" + message;
            });
        }
    });
}]);