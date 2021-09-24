using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5.Models;
using Lesson5.Infrastructure;

namespace Lesson5.Controllers
{
    public class RemoteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User newUser)
        {
            if (ModelState.IsValid)
            {
                return View("NewUserCreated", newUser);
            }
            return View(newUser);


        }

        public JsonResult UniqueUserName(string Username)
        {
            if(Users.UsernameIsUnique(Username))
            {
                return Json(true);
            }
            else
            {
                return Json("This username already exists");
            }
           
        }
    }
}
