angular.module('foodiesController', []).controller('foodiesController', function($scope, $q, foodiesService) {

    // App section
    $scope.currentUser = null;
    $scope.allIngredients = [];
    $scope.currentPage = 0;

    // Register page
    $scope.registerName = '';
    $scope.registerPassword = '';

    // Recepies page
    $scope.currentFilter = null;
    $scope.currentSort = null;
    $scope.currentRecepies = [];
    $scope.categories = [];

    // Scope functions

    $scope.getAllIngredients = function () {
        if ($scope.currentUser) {
            foodiesService.GetIngredientsService($scope.currentUser.Id).then(function(data){
                $scope.allIngredients = data;
                $scope.currentPage = 2;
            });
        }
    }

    $scope.attemptLogin = function () {
        if ($scope.registerName.length > 0 && $scope.registerPassword.length > 0) {
            foodiesService.ConnectUserService($scope.registerName, $scope.registerPassword).then(function(data){
                if (data) {
                    $scope.currentUser = data;
                    $scope.currentPage = 1;
                }
            });
        }
    }

    $scope.getRecepiesByFilter = function () {
        foodiesService.GetRecepiesService($scope.currentFilter, $scope.currentSort).then(function(data){
            $scope.currentRecepies = data;
            $scope.currentPage = 3;
        });
    }

    $scope.getAllCategories = function () {
        foodiesService.GetCategoriesService().then(function(data){
            $scope.categories = data;
        });
    }

    $scope.addUser = function () {
        if($scope.registerName.length > 0 && $scope.registerPassword.length > 0) {
            foodiesService.AddUserService($scope.registerName, $scope.registerPassword).then(function(data){
                $scope.attemptLogin($scope.registerName, $scope.registerPassword);
            });
        }
    }

    $scope.addIngredient = function () {
        foodiesService.AddIngredientService().then(function(){
            $scope.getAllIngredients();
        });
    }
    
    
    // Controller init

    $scope.getAllCategories();
    
});