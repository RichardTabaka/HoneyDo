using HoneyDo.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDo.Models
{
    public class ToDoItem
    {
        [StringLength(90)]
        [Display(Name = "Title:")]
        [MyCustomValidation]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Description Required")]
        [Display(Name = "Description:")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Must Provide To Do Status")]
        [Display(Name = "Done:")]
        public bool Completed { get; set; }
    }
}
