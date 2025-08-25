using InnoLaunch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InnoLaunch.Controllers
{
    public class StartupController : Controller
    {
        private readonly InnoLaunchDbContext _context;

        public StartupController(InnoLaunchDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var startups = _context.Startups.Include(s => s.Founder).ToList();

            return View(startups);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Founders = new SelectList(_context.Founders, "FounderId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Startup startup)
        {
            if (ModelState.IsValid)
            {
                _context.Startups.Add(startup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(startup);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var startup = _context.Startups.Find(id);
            if (startup == null) return NotFound();
            return View(startup);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Startup startup)
        {
            if (ModelState.IsValid)
            {
                _context.Startups.Update(startup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(startup);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var startup = _context.Startups.Find(id);
            if (startup == null)
                return NotFound();

            return View(startup);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var startup = _context.Startups.Find(id);
            if (startup != null)
            {
                _context.Startups.Remove(startup);
                _context.SaveChanges();
                TempData["StatusMessage"] = "Category deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
