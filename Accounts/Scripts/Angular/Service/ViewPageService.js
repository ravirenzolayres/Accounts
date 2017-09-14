(function () {
    'use strict';
    angular
    .module('myApp')
    .factory('ViewPageService', ViewPageService);
    ViewPageService.$inject = ['$http'];

    function ViewPageService($http) {
        return {
            loadpage: loadpage,
            showAddModal: showAddModal,
            submitUser: submitUser,
            editUser: editUser,
            readEmployees: readEmployees,
            changeStatus: changeStatus,
            deletefunction: deletefunction
           
        }

        function loadpage() {
            return $http({
                method: 'POST',
                url: '../ViewPage/LoadPageData',
            });
        }

        function showAddModal() {
            return $http({
                method: 'POST',
                url: '../ViewPage/LoadRoles'
            });
        }

        function submitUser(user, roles) {
            return $http({
                method: 'POST',
                url: '../ViewPage/AddUser',
                data: {
                    user: user,
                    roles: roles
                }
            });
        }

        function editUser(user) {
            return $http({
                method: 'POST',
                url: '../ViewPage/EditUser',
                data: {
                    user: user,
                }

            });
        }

        function readEmployees() {
            return $http({
                method: 'POST',
                url: '../ViewPage/ReadEmployees'
            });
        }

        function changeStatus(userid) {
            return $http({
                method: 'POST',
                url: '../ViewPage/ChangeStatus',
                data: {
                    userid: userid
                }
            });
        }

        function deletefunction(userId) {
            return $http({
                method: 'POST',
                url: '../ViewPage/DeleteUser',
                data: {
                    userId: userId
                }
            });
        }
    }
})();