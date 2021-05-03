using ASPPart2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPPart2.Controllers
{
    public class LearningController : Controller
    {
        public LearningController()
        {
            
        }
        

        public IActionResult GettingStarted()
        {
            return View();
        }
    }
}
