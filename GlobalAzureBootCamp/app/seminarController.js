angular.module("App").controller("seminarController", function ($scope, seminarFactory) {
    $scope.seminare = seminarFactory.query();


    $scope.save = function (vm) {
        vm.Datum = new Date(vm.Datum);
        seminarFactory.save(vm);
  
    };
    var rproxy = $.connection.myHub1;
    rproxy.on('addHannes', function (s) {
        $scope.$apply(function () {$scope.seminare.push(s); });
      
    });

    $.connection.hub.start();

});