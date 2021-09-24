using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Lesson5.Models;

namespace Lesson5.Infrastructure
{
    public class MinimumCheckedAttribute: Attribute, IModelValidator
    {
        public bool IsRequired => true;
        public string ErrorMessage { get; set; } = "Please choose at least one breakfast item!";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            List<BreakfastFood> value = context.Model as List<BreakfastFood>;
            bool atLeastOne = false;
            foreach(BreakfastFood food in value)
                {
               if(food.Selected)
                {
                    atLeastOne = true;
                }
                }

            if (atLeastOne == false)
            {
                return new List<ModelValidationResult> {
                    new ModelValidationResult("", ErrorMessage)};
            }
            else
            {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}
