using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HoneyDo.Data;
using HoneyDo.Models;

namespace HoneyDo.Controllers
{
    public class HiveController : Controller
    {
        private HiveContext _context;
        public HiveController( HiveContext mainContextDB)
        {
            _context = mainContextDB;
        }
        public IActionResult HiveDisplayer()
        {
            return View(_context.Hives.ToList());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hive = _context.Hives.SingleOrDefault(h => h.HiveId == id);
            return View(hive);
        }
        [HttpPost]
        public IActionResult Edit(Hive h, int id)
        {
            var hive = _context.Hives.SingleOrDefault(h => h.HiveId == id);
            hive.HiveName = h.HiveName;
            hive.HoneyProduced = h.HoneyProduced;
            hive.Location = h.Location;
            hive.BeeType = h.BeeType;
            hive.BeeCount = h.BeeCount;
            _context.Update(hive);
            _context.SaveChanges();
            return RedirectToAction("HiveDisplayer");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Hive h)
        {
            _context.Update(h);
            _context.SaveChanges();
            return RedirectToAction("HiveDisplayer");
        }
        public IActionResult Delete(int id)
        {
            var hive = _context.Hives.SingleOrDefault(h => h.HiveId == id);
            _context.Remove(hive);
            _context.SaveChanges();

            return RedirectToAction("HiveDisplayer");
        }


    }
}
