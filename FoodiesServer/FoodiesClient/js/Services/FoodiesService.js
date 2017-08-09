angular.module('foodiesService', []).service('foodiesService', ['$http', '$q', function ($http, $q) {
    this.GetIngredientsService = function(userID){
      return $http({
            url: 'http://localhost:63236/Foodies/GetAllIngredients', 
            method: "GET",
            params: {UserId: userID}
      })
        .then(function (response, status) {
            // The return value gets picked up by the then in the controller.
            return $q.resolve(response);
        });
    }
    
     this.GetRecepiesService = function(categoryID, sort){
        return $http({
            url: 'http://localhost:63236/Foodies/GetRecepies', 
            method: "GET",
            params: {CategotyId:categoryID, Sort:sort}
        });
  }
     
     this.ConnectUserService = function(UserName, Password){
        var dataObj = {
            userName : UserName,
            password : Password
        };
        return $http({
            url: 'http://localhost:63236/Foodies/AttemptLogin', 
            method: "GET",
            params: {userName: UserName, password: Password}
        });
  }
     this.AddUserService = function(UserName, Password){
      return $http.put('http://localhost:63236/Foodies/AddUser',                                     
          {},                                          
          { params: { userName: UserName, password : Password } }   
       );
    }
     
      this.AddIngredientService = function(barcode){
      $http.put('http://localhost:63236/Foodies/AddIngredient',                                     
          {},                                          
          { params: { barcode: barcode} }   
       );
    }
      
       this.GetCategoriesService = function(){        
        return ($http.get('http://localhost:63236/Foodies/GetAllCategories'));
   }
}]);
