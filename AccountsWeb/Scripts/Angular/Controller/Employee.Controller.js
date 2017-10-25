(function () {
    'use strict';

    angular
        .module('App')
        .controller('EmployeeController', EmployeeController);

    EmployeeController.$inject = ['$filter', 'EmployeeService'];

    function EmployeeController($filter, EmployeeService) {
        var vm = this;

        vm.EmployeeId;

        vm.Employee;

        vm.Employees = [];
        
        vm.Initialise = Initialise;

        function Initialise(employeeId) {
            vm.EmployeeId = employeeId;
            Read();
        }

        function Read() {
            EmployeeService.Read()
                .then(function (response) {
                    vm.Employees = response.data;
                    UpdateEmployee();
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

        function UpdateEmployee() {
            vm.Employee = $filter('filter')(vm.Employees, { EmployeeId: vm.EmployeeId })[0];
        }
    }
})();