using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCCoffeeShop.Models;

namespace MVCCoffeeShop.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registered(
            Users user)
        {
          return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        //method that uses tempData to store userLoggedIn, showBuyButton, 

        public IActionResult LogIn(Users user, string userNameInput, string passwordInput) {


            //make a new action that will search the DB for my result
            // Use my context class to pull in my DataBase data
                ShopDbContext db = new ShopDbContext();

                // make an individual Person object to store my result in
                Users foundResult = new Users();

            // make a TempData object and set it to false - showButton, loggedIn, 
            //create empty loggedInUser in tempData OR 
                // this allows me to later set it to true if I find a match
                TempData["loggedIn"] = false;
                //Session["loggedInUser"] = null;

            // i need to find my result in my DB
            foreach (Users foundUser in db.Users)
                {
                // as i iterate through the collection, I want to find the correct result
                if (foundUser.Username == userNameInput && foundUser.Password == passwordInput) {
                        // if you find a match, assign that value to your temp Person object
                        //here is where we could be assigning foundResult to our session
                        foundResult = user;
                    //Session["loggedInUser"] = user;

                    // You found a match, set your TempData to true
                    // this allows us to display certain HTML
                    TempData["loggedIn"] = true;
                    TempData.Keep("loggedIn");
                    
                    }
                }
                // pass the object with the data to the view to be displayed
                return View(foundResult);
            }
        

        public IActionResult MakeNewUser(Users user)
        {
            // Use my context class to pull in my DataBase data
            ShopDbContext db = new ShopDbContext();

            // Insert 
            db.Users.Add(user);
            db.SaveChanges();

            return Registered(user);
        }

        //method called from click of Buy button
        public IActionResult AttemptTransaction(Items item, Users user)
        { 
            ShopDbContext db = new ShopDbContext();
            //store user

            //store item they selected



            // as i iterate through the collection, I want to find the correct result
            if (user.Funds >= item.Price)
            {
                return TransactionSuccess(user, item);
            }
                return TransactionError(user, item);
            }

        public IActionResult TransactionSuccess(Users user, Items item) {
            ShopDbContext db = new ShopDbContext();

            //Create a public int originalFunds = loggedInUser.Funds
            //public int userFunds = loggedInUser.funds;
            //public int itemPrice = items.price;
            //public int newBalance = (userFunds - itemPrice);
            //public int ItemPrice = item1.Price
            //public int NewFundBalance = originalFunds - ItemPrice

            //DONT FORGET TO UPDATE THE DATABASE AND SAVECHANGES
            //db.SaveChanges();
            return View();
        }

        public IActionResult TransactionError(Users user, Items item) {
            return View();
        }

        public IActionResult RegistrationView()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
