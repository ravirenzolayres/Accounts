//$(document).ready(function () {
//    document.getElementById("middlename").defaultValue = " ";
//});

//function addfunction() {
//    $("#addModal").modal("show");
//}
//var app = angular.module("myApp", []);
//app.controller("myCtrl", function ($scope, $http) {

    //======DISPLAY USERS========//
    //$scope.initialize = function () {
    //    $scope.page;
    //    $scope.loadpage();
    //}

    ////======LOAD USERS IN PAGE========//
    //$scope.pageChange = function (page) {
    //    $scope.page = page;
    //    $scope.loadpage(page.PageNumber, page.PageStatus);
    //}
    //$scope.loadpage = function () {
    //    $http.post("/ViewPage/LoadPageData").then(
    //        function successCallback(response) {
    //            $scope.accounts = response.data;
    //        },
    //        function errorCallback(response) {
    //        }
    //    );
    //}

    //======REMOVES DATA IN INPUT========//
    //$scope.closefunction = function () {
    //    $scope.username = '';
    //    $scope.lastname = '';
    //    $scope.firstname = '';
    //    $scope.middlename = '';
    //    $scope.department = '';
    //    $scope.contact = '';
    //    $scope.email = '';
    //    $scope.checkedRoles = [];
    //    $scope.enableButton = false;
    //    $("#addModal").modal("hide");
    //}

    //======OPENS THE MODAL AND LOAD ALL ROLES========//
    //$scope.adduserfunction = function () {
    //    $http.post('/ViewPage/LoadRoles')
    //            .then(
    //        function successCallback(response) {
    //            $scope.roles = response.data;
    //        },
    //        function errorCallback(response) {

    //        });
    //}

    //======ADD USER TO DATABASE========//
    //$scope.clickfunction = function () {
    //    var data = {
    //        username: $scope.username,
    //        lastname: $scope.lastname,
    //        firstname: $scope.firstname,
    //        middlename: $scope.middlename,
    //        department: $scope.department,
    //        contact: $scope.contact,
    //        email: $scope.email,
    //        roles: $scope.roles
    //    };
    //    $http.post('/ViewPage/AddUser', data)
    //        .then(
    //    function successCallback(response) {
    //        $scope.loadpage();
    //        $scope.username = '';
    //        $scope.lastname = '';
    //        $scope.firstname = '';
    //        $scope.middlename = '';
    //        $scope.department = '';
    //        $scope.contact = '';
    //        $scope.email = '';
    //        $scope.checkedRoles = [];
    //        $scope.enableButton = false;
    //        $("#addModal").modal("hide");
    //    },
    //    function errorCallback(response) {
    //    });
    //}

    //======DELETE USER TO DATABASE========//
    //$scope.deletefunction = function (id) {
    //    var data = {
    //        userid: id
    //    };
    //    $http.post("/ViewPage/DeleteUser", data).then(
    //        function successCallback(response) {
    //            if (response.data.Data.length) {
    //                $scope.loadpage();
    //            }
    //            else {
    //                $scope.loadpage();
    //            }
    //        },
    //        function errorCallback(response) {
    //        }
    //    );
    //}

    //======CHANGE USER STATUS TO DATABASE========//
    //$scope.changeStatus = function (userid) {
    //    var data = {
    //        userid: userid
    //    };
    //    $http.post("/ViewPage/ChangeStatus", data).then(
    //        function successCallback(response) {
    //            $scope.loadpage();
    //        },
    //        function errorCallback(response) {
    //        }
    //    );
    //}

    //======EDIT USER TO DATABASE========//
    //$scope.editfunction = function () {
    //    var data = {
    //        user: $scope.account
    //    };
    //    $http.post("/ViewPage/EditUser", data).then(
    //        function successCallback(response) {
    //            $scope.loadpage();
    //            $scope.checkedRoles = [];
    //            $("#editModal").modal("hide");
    //        },
    //        function errorCallback(response) {
    //        }
    //    );
    //}

    //$scope.showEditModal = function (account) {
    //    $scope.account = angular.copy(account);
    //    $scope.checkButtonState(account.Roles)
    //    $("#editModal").modal("show");
    //}

    //======RESTRICTION=====//
//    $scope.checkButton = function () {
//        $scope.checkedRoles = [];
//        angular.forEach($scope.roles, function (role) {
//            if (role.RoleStatus) {
//                $scope.checkedRoles.push("1");
//            }
//        });
//        $scope.enableButton = $scope.checkedRoles.length > 0;
//    };

//    $scope.checkButtonState = function (roles) {
//        $scope.checkedRoles = [];
//        angular.forEach(roles, function (role) {
//            if (role.RoleStatus) {
//                $scope.checkedRoles.push("1");
//            }
//        });
//        $scope.enableButton = $scope.checkedRoles.length > 0;
//    };




//});