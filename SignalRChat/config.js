"use strict";
(function (global) {
    function registerHubFactory($provide, hubName) {
        $provide.factory(hubName, function () {
            var proxy = $.connection.hub.createHubProxy(hubName);
            return proxy;
        });
    }

    function __nothing() { }

    function setupAndRegisterProxies($provide) {

        for (var property in $.connection) {
            var value = $.connection[property];
            if (typeof value !== "undefined" && value !== null) {
                if (typeof value.hubName !== "undefined" && value !== null) {
                    var hubName = property;
                    var proxy = $.connection.hub.createHubProxy(hubName);

                    // Remarks about the following line:
                    // - SignalR tells the server what hubs its interested in on startup. 
                    //   If there are no client calls, it won't receive messages
                    proxy.client.__need_this_for_subscription__ = __nothing;
                    registerHubFactory($provide, hubName);
                }
            }
        }
    }

    var application = angular.module("SignalRChat", ["ng"]);
    application.config(["$provide", 
        function ($provide) {
            setupAndRegisterProxies($provide);

            $.connection.hub.start().done(function () {
                console.log("Hub connection up and running");
            });

            var chatConnection = $.connection("/chat");
            chatConnection.start().done(function () {
                console.log("Started");
            });

            $provide.constant("chatConnection", chatConnection);
        }
    ]);

    global.$application = application;
})(window);
