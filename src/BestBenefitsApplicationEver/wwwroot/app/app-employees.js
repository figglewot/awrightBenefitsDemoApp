(function () {
    angular.module("app-employees", ["reusableControls", "ngRoute"])
        .config(function ($routeProvider) {

            $routeProvider.when("/", {
                controller: "employeesController",
                controllerAs: "viewModel",
                templateUrl: "views/employeesView.html"
            });

            $routeProvider.when("/addNewEmployee", {
                controller: "employeesController",
                controllerAs: "viewModel",
                templateUrl: "views/addNewEmployeeView.html"
            });

            $routeProvider.when("/editEmployee/:employeeId", {
                controller: "employeeEditorController",
                controllerAs: "viewModel",
                templateUrl: "views/employeeEditorView.html"
            });

            $routeProvider.when("/deleteEmployee/:employeeId", {
                controller: "employeeDeleteController",
                controllerAs: "viewModel",
                templateUrl: "views/employeesView.html"
            });

            $routeProvider.when("/addDependents/:employeeId", {
                controller: "dependentsController",
                controllerAs: "viewModel",
                templateUrl: "views/addDependentsView.html"
            });

            $routeProvider.when("/viewEmployeeDetails/:employeeId", {
                controller: "employeeDetailController",
                controllerAs: "viewModel",
                templateUrl: "views/viewEmployeeDetailsView.html"
            });

            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();