(function () {
    'use strict';

    angular
    .module('myApp')
    .controller('ViewPageController', ViewPageController);

    ViewPageController.$inject = ['$filter', 'ViewPageService'];

    function ViewPageController($filter, ViewPageService) {
        var vm = this;
        vm.user = {
            username: '',
            employees: '',            
            checkedRoles: [],
        };

        vm.accounts = [];
        vm.employees = [];       
        vm.roles = [];
        vm.initialize = initialize;
        vm.showAddModal = showAddModal;
        vm.submitUser = submitUser;
        vm.checkedBox = checkedBox;
        vm.showEditModal = showEditModal;
        vm.editUser = editUser;
        vm.closefunction = closefunction;
        vm.changeStatus = changeStatus;
        vm.updateFirstname = updateFirstname;
        vm.deletefunction = deletefunction;


        function loadpage() {
            ViewPageService.loadpage()
                .then(function (response) {
                    vm.accounts = response.data;
                })
                .catch(function (response) {
                });
        }

        function readEmployees() {
            ViewPageService.readEmployees()
                .then(function (response) {
                    vm.employees = response.data;
                })
                .catch(function (response) {
                });
        }

        function initialize() {
            loadpage();
            readEmployees();
        }

        function showAddModal() {
            angular.element("#addModal").modal("show");
            ViewPageService.showAddModal()
                .then(function (response) {
               vm.roles = response.data;
                })
                .catch(function (response) {
                });
        }

        function submitUser() {
            ViewPageService.submitUser(vm.user, vm.roles)
                .then(function (response) {
                    loadpage();
                    closefunction()
                })
                .catch(function (response) {
                });
        }

        function checkedBox() {
            vm.checkedRoles = [];
            angular.forEach(vm.roles, function (role) {
                if (role.RoleStatus) {
                    vm.checkedRoles.push("1");
                }
            });
            vm.enableButton = vm.checkedRoles.length > 0;
        }
    
        function showEditModal(account) {
            vm.account = angular.copy(account);
            vm.account.Employee = $filter('filter')(vm.employees, { EmployeeId: vm.account.EmployeeId})[0];
            vm.checkedBox(account.Roles);
            angular.element("#editModal").modal("show");            
        };

        function editUser() {
            vm.user = vm.account
            ViewPageService.editUser(vm.user)
                .then(function (response) {
                    loadpage();
                    vm.checkedRoles = [];
                    angular.element("#editModal").modal("hide");
                })
                .catch(function (response) {
                });
        }

        function changeStatus(userid) {
            ViewPageService.changeStatus(userid)
                .then(function (response) {
                    loadpage();
                })
                .catch(function (response) {
                });
        }

        function closefunction() {
            vm.user = {
                username: '',               
                firstname: '',
               
                checkedRoles: [],
            };
            vm.enableButton = false;
            angular.element("#addModal").modal("hide");
        }

        function updateFirstname(account) {
            var employee = $filter('filter')(vm.employees, { EmployeeId: account.EmployeeId })[0];
            account.Firstname = employee.FirstName;
        }

        function deletefunction(userId) {
            ViewPageService.deletefunction(userId)
                .then(function (response) {
                    vm.accounts = response.data.Data;
                })
                .catch(function (response) {
                });
        }
    }
})();   