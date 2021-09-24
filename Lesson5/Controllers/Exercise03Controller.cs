using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lesson5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lesson5.Controllers
{
    public class Exercise03Controller : Controller
    {
        public IActionResult Index()
        {
            BreakfastOrder breakfastOrder = new BreakfastOrder();
            //when using curly brackets here, you're not passing into the constructor but setting the properties directly, instead of 
            //new class()
            //class.prop1 = "somevalue"
            breakfastOrder.addBreakfastFood(new BreakfastFood { BreakfastFoodId = 1, Name = "Cornflakes", Price = 36, Selected = false });
            breakfastOrder.addBreakfastFood(new BreakfastFood { BreakfastFoodId = 2, Name = "Eggs", Price = 16, Selected = false });
            breakfastOrder.addBreakfastFood(new BreakfastFood { BreakfastFoodId = 3, Name = "Toast", Price = 10, Selected = false });
            breakfastOrder.addBreakfastFood(new BreakfastFood { BreakfastFoodId = 4, Name = "Juice", Price = 4, Selected = false });
            breakfastOrder.addBreakfastFood(new BreakfastFood { BreakfastFoodId = 5, Name = "Coffee", Price = 3, Selected = false });
            breakfastOrder.addBreakfastFood(new BreakfastFood { BreakfastFoodId = 6, Name = "Tea", Price = 2, Selected = false });
            //return the view with model as parameter, creates strongly typed view:
            return View(breakfastOrder);
        }




        [HttpPost]
        public IActionResult Index(BreakfastOrder breakfastOrder)
        {
            if (ModelState.IsValid)
            {
                return View("Receipt", breakfastOrder);
            }
            return View(breakfastOrder);


        }
    }
}
