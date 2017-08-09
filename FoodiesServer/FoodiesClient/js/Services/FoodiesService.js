foodiesApp.factory('GetIngredientsService', ['$http', function ($http) {
    this.Ingredients = function(userID){
      return $http({ method: 'POST', url: 'http://localhost/AddIngredient', UserID: userID});
  }
}]);

foodiesApp.factory('GetRecepiesService', ['$http', function ($http) {
    this.Recepie = function(categoryID, sort){
      return $http({ method: 'POST', url: 'http://localhost/GetRecepies', {CategotyId:categoryID, Sort:sort}});
  }
}]);

foodiesApp.factory('ConnectUserService', ['$http', function ($http) {
    this.User = function(UserName, Password){
      return $http({ method: 'POST', url: 'http://localhost/AttemptLogin', {userName:UserName, password:Password}});
  }
}]);

foodiesApp.factory('AddUserService', ['$http', function ($http) {
    this.User = function(UserName, Password){
      $http.put('http://localhost/AddUser',                                     
          {},                                          
          { params: { userName: UserName, password : Password } }   
       );
    }
}]);

foodiesApp.factory('AddIngredientService', ['$http', function ($http) {
    this.Ingredient = function(ID, Name, PictureURL, Calories, UserID){
      $http.put('http://localhost/AddIngredient',                                     
          {},                                          
          { params: { id: ID, name: Name, pictureUrl: PictureURL, calories: Calories, userId: UserID} }   
       );
    }
}]);

foodiesApp.factory('GetCategoriesService', ['$http', function ($http) {
    this.Category = function(){
      return $http({ method: 'GET', url: 'http://localhost/GetAllCategories');
  }
}]);
