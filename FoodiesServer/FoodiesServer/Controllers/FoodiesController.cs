﻿using FoodiesServer.DAL;
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

        [HttpGet]
        public List<Ingredient> GetAllIngredients(int UserId) {
            return dal.GetAllIngredients(UserId);
        }

        [HttpGet]
        public List<Recepie> GetRecepies(int CategoryId, bool Sort)
        {
            RecepieFilter filter = new RecepieFilter(CategoryId, Sort);
            return dal.GetRecepiesByFilter(filter);
        }

        [HttpGet]
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
        public void AddIngredient(string barcode, int userID)
        {
            dal.AddIngridient(barcode, userID);
        }

        [HttpGet]
        public IEnumerable<RecepieCatgory> GetAllCategories()
        {
            return dal.GetAllCategories();
        }
    }
}
