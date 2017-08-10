angular.module('foodiesService', []).service('foodiesService', ['$http', '$q', function ($http, $q) {
    this.GetIngredientsService = function(userID){
      return $http({
            url: 'http://localhost:63236/Foodies/AddIngredient', 
            method: "GET",
            params: {UserID: userID}
        });
    }
    
     this.GetRecepiesService = function(categoryID, sort){
         if(!categoryID){
             categoryID = -1;
         }
        return $http({
            url: 'http://localhost:63236/Foodies/GetRecepies', 
            method: "GET",
            params: { CategoryId: categoryID, Sort:false }
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
     
      this.AddIngredientService = function(ID, Name, PictureURL, Calories, UserID){
      $http.put('http://localhost:63236/Foodies/AddIngredient',                                     
          {},                                          
          { params: { id: ID, name: Name, pictureUrl: PictureURL, calories: Calories, userId: UserID} }   
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
