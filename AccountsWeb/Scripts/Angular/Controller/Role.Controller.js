(function () {
    'use strict';

    angular
        .module('App')
        .controller('RoleController', RoleController);

    RoleController.$inject = ['$filter', 'RoleService'];

    function RoleController($filter, RoleService) {
        var vm = this;

        vm.UserId;
        
        vm.AssignedRoles = [];
        vm.Roles = [];
        
        vm.Initialise = Initialise;

        function Initialise(userId) {
            vm.UserId = userId;
            Read();
            ReadAssignedRole();
        }

        function Read() {
            RoleService.Read()
                .then(function (response) {
                    vm.Roles = response.data;
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

        function ReadAssignedRole() {
            RoleService.ReadAssignedRole(vm.UserId)
                .then(function (response) {
                    vm.AssignedRoles = response.data;
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