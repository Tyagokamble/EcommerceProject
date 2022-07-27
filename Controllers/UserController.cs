using Ecommerce_Project.DAL;
using Ecommerce_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Project.Controllers
{
    public class UsersController : Controller
    {
        UserDAL db = new UserDAL();
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User user)
        {
            try
            {
                int res = db.UserSignUp(user);
                if (res == 1)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(User user)
        {
            User user1 = db.UserLogin(user);
            if (user.Password == user.Password)
            {
                HttpContext.Session.SetString("username", user.FName + " " + user.LName);
                HttpContext.Session.SetString("userid", user.Id.ToString());
                return RedirectToAction("Index", "Product");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("SignIn");
        }
    }

}
