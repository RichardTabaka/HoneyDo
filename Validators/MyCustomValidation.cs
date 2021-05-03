using HoneyDo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDo.Validators
{
    public class MyCustomValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ToDoItem td = (ToDoItem)validationContext.ObjectInstance;
            if (td.Title != null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("The Title may not be null");
            }
        }
    }
}
