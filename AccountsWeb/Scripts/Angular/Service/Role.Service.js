(function () {
    'use strict';

    angular
        .module('App')
        .factory('RoleService', RoleService);

    RoleService.$inject = ['$http'];

    function RoleService($http) {
        return {
            Read: Read,
            ReadAssignedRole: ReadAssignedRole
        }

        function Read() {
            return $http({
                method: 'POST',
                url: '/Role/Read',
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }

        function ReadAssignedRole(userId) {
            return $http({
                method: 'POST',
                url: '/Role/ReadAssignedRole/' + userId,
                headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
            });
        }
    }
})();