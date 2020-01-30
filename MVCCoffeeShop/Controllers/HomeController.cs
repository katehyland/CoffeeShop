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
          return View("Register", user);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
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

        //public bool Validation()
        //{
        //    //password value
        //    //confirm password value

        //    if (password === confirmpassword)
        //    {
        //        return true;
        //    }
        //     return false;
        //}

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
