angular.module('foodiesService', []).service('foodiesService', ['$http', '$q', function ($http, $q) {
    this.GetIngredientsService = function(){
      return $http({
            url: 'http://localhost:63236/Foodies/GetAllIngredients/', 
            method: "GET",
            params: {UserID: 1}
      });
    }
    
     this.GetRecepiesService = function(categoryID, sort){
         if(!categoryID){
             categoryID = -1;
         }
        return $http({
            url: 'http://localhost:63236/Foodies/GetRecepies', 
            method: "GET",
            params: { CategoryId: categoryID, Sort:false, userId: 1 }
        });
  }
     
     this.ConnectUserService = function(UserName, Password){
        var dataObj = {
            userName : UserName,
            password : Password
        };
        var q =  $http({
            url: 'http://localhost:63236/Foodies/AttemptLogin', 
            method: "GET",
            params: {userName: UserName, password: Password}
        });

        q.then(function(data){
            this.user = data.data;
        }, this);

        return q;
  }
     this.AddUserService = function(UserName, Password){
      return $http.put('http://localhost:63236/Foodies/AddUser',                                     
          {},                                          
          { params: { userName: UserName, password : Password } }   
       );
    }
     
      this.AddIngredientService = function(barcode, userId){
      $http.put('http://localhost:63236/Foodies/AddIngredient',                                     
          {},                                          
          { params: { barcode: barcode, userID: 1} }   
       );
    }
      
       this.GetCategoriesService = function(){        
        return ($http.get('http://localhost:63236/Foodies/GetAllCategories'));
   }

   this.GetRecepieIngs = function(recepieId){
        return $http({
            url: 'http://localhost:63236/Foodies/GetAllRecepieIngs', 
            method: "GET",
            params: {recepieId: recepieId}
        });
   }
}]);
