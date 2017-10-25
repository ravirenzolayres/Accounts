(function () {
    'use strict';

    angular
        .module('App')
        .controller('UserController', UserController);

    UserController.$inject = ['$window', 'UserService'];

    function UserController($window, UserService) {
        var vm = this;

        vm.Employees = [];
        vm.Users = [];

        vm.GoToUpdatePage = GoToUpdatePage;
        vm.Initialise = Initialise;

        vm.Delete = Delete;
        
        function GoToUpdatePage(userId) {
            $window.location.href = '../User/Update/' + userId;
        } 

        function Initialise() {
            Read();
        }

        function ReadEmployees() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Read() {
            UserService.Read()
                .then(function (response) {
                    vm.Users = response.data;
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });

                });
        }

        function Delete(userId) {
            UserService.Delete(userId)
                .then(function (response) {
                    Read();
                })
                .catch(function (data, status) {
                    new PNotify({
                        title: status,
                        text: data,
                        type: 'error',
                        hide: true,
                        addclass: "stack-bottomright"
                    });
                });
        }

    }
})();