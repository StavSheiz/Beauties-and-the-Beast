using FoodiesServer.DAL;
using FoodiesServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodiesServer.Contollers
{
    public class FoodiesController : ApiController
    {
        private FoodiesDAL dal;

        public FoodiesController()
        {
            dal = new FoodiesDAL();
        }

        [HttpPost]
        public List<Ingredient> GetAllIngredients(int UserId) {
            return dal.GetAllIngredients(UserId);
        }

        [HttpPost]
        public List<Recepie> GetRecepies(int CategoryId, bool Sort)
        {
            RecepieFilter filter = new RecepieFilter(CategoryId, Sort);
            return dal.GetRecepiesByFilter(filter);
        }

        [HttpPost]
        public User AttemptLogin(string userName, string password)
        {
            User u = new User(userName, password);
            return dal.AttemptLogin(u);
        }

        [HttpPut]
        public void AddUser(string userName, string password)
        {
            User u = new User(userName, password);
            dal.AddUser(u);
        }

        [HttpPut]
        public void AddIngredient(int id, string name, string pictureUrl, int calories, int userId)
        {
            Ingredient ing = new Ingredient(id, name, calories, pictureUrl);
            dal.AddIngridient(ing, userId);
        }
    }
}
