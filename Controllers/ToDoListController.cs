using HoneyDo.Models;
using HoneyDo.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneyDo.Controllers
{
    public class ToDoListController : Controller
    {
        private IToDoList TempData;

        public ToDoListController(IToDoList myService)
        {
            TempData = myService;
        }
        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult Display(int id)
        {
            // Display Action needs some work, struggled to add route to specific items to display and so included info in List.cshtml
            return View(TempData.ToDoItems[id]);
        }

        public IActionResult List()
        {
            return View(TempData.ToDoItems);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ToDoItem td)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.ToDoItems.Add(td);
            return RedirectToAction("List");
        }
        [HttpGet]
        public IActionResult Remove(int id)
        {
            ViewBag.id = id;
            return View(TempData.ToDoItems[id]);
        }
        [HttpPost]
        public IActionResult RemovePost(int id)
        {
            TempData.ToDoItems.RemoveAt(id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if(id < 0 || id > TempData.ToDoItems.Count)
            {
                return Content("Invalid ID");
            }
            return View(TempData.ToDoItems[id]);
        }
        [HttpPost]
        public IActionResult Edit(int id, ToDoItem td)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            TempData.ToDoItems[id] = td;
            return RedirectToAction("List");
        }
    }
}
