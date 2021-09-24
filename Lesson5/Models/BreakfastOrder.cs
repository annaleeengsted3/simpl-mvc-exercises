using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Lesson5.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson5.Models
{
    public class BreakfastOrder
    {
        [Required]
        [RegularExpression("^[a-zA-Z]{2,}(?: [a-zA-Z]+){0,2}",
         ErrorMessage = "Please enter your full name")]
        [DisplayName("Your Full Name")]
        public string FullName { get; set; }
        [Required]
        [DisplayName("Room Number")]
        public int? RoomNumber { get; set; }
        [Required]
        [FutureDate]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy hh:mm}", ApplyFormatInEditMode = true)] 
        public DateTime Delivery { get; set; } = DateTime.Now; // DateTime.Now is the default value
        [MinimumChecked]
        public List<BreakfastFood> BreakfastFoods { get; private set; } = new List<BreakfastFood>();

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (BreakfastFood breakfastFood in BreakfastFoods)
                {
                    if (breakfastFood.Selected == true)
                    {

                        totalPrice = totalPrice + breakfastFood.Price;
                    }
                }
                return totalPrice;
            }
        }


        public void addBreakfastFood(BreakfastFood food)
        {

            BreakfastFoods.Add(food);
        }
    }
}
