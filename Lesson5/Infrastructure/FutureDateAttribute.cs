using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace Lesson5.Infrastructure
{
    public class FutureDateAttribute : Attribute, IModelValidator {
        public bool IsRequired => true;
        public string ErrorMessage { get; set; } = "Please enter a date in the future";
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context) {
            DateTime? value = context.Model as DateTime ?;

            if (value != null && (DateTime)value < DateTime.Now && ((DateTime)value).AddYears(120) > DateTime.Now) {
                return new List<ModelValidationResult> {
                    new ModelValidationResult("", ErrorMessage)};
            }
            else {
                return Enumerable.Empty<ModelValidationResult>();
            }
        }
    }
}
