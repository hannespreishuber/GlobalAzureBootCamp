angular.module("App").factory("seminarFactory", function ($resource) {
    return $resource('/api/Seminare/:id');

});