angular.module('foodiesService', []).service('foodiesService', ['$http', '$q', function ($http, $q) {
    this.GetIngredientsService = function(userID){
      return $http({ method: 'POST', url: 'http://localhost/Foodies/AddIngredient', UserID: userID});
    }
    
     this.GetRecepiesService = function(categoryID, sort){
      return $http({ method: 'POST', url: 'http://localhost/Foodies/GetRecepies', CategotyId:categoryID, Sort:sort});
  }
     
     this.ConnectUserService = function(UserName, Password){
      return $http({ method: 'POST', url: 'http://localhost/Foodies/AttemptLogin', userName:UserName, password:Password});
  }
     this.AddUserService = function(UserName, Password){
      return $http.put('http://localhost:63236/Foodies/AddUser',                                     
          {},                                          
          { params: { userName: UserName, password : Password } }   
       );
    }
     
      this.AddIngredientService = function(ID, Name, PictureURL, Calories, UserID){
      $http.put('http://localhost/Foodies/AddIngredient',                                     
          {},                                          
          { params: { id: ID, name: Name, pictureUrl: PictureURL, calories: Calories, userId: UserID} }   
       );
    }
      
       this.GetCategoriesService = function(){
  //    return $http({ method: 'GET', url: 'http://localhost/Foodies/GetAllCategories');
 //       );
                    
        return ($http.get('http://localhost/Foodies/GetAllCategories')).then(function (response, status) {
            // The return value gets picked up by the then in the controller.
            return $q.resolve(response.data);
        });
   }
}]);
