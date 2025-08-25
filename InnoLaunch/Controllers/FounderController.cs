using InnoLaunch.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace InnoLaunch.Controllers
{
    public class FounderController : Controller
    {
        private readonly InnoLaunchDbContext _context;

        public FounderController(InnoLaunchDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            var founders = await _context.Founders.ToListAsync();
            return View(founders);

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Founder founder)
        {
            if (ModelState.IsValid)
            {
                _context.Founders.Add(founder);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(founder);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var founder = _context.Founders.Find(id);
            if (founder == null) return NotFound();
            return View(founder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Founder founder)
        {
            if (ModelState.IsValid)
            {
                _context.Founders.Update(founder);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(founder);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var founder = _context.Founders.Find(id);
            if (founder == null)
                return NotFound();

            return View(founder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var founder = _context.Founders.Find(id);
            if (founder != null)
            {
                _context.Founders.Remove(founder);
                _context.SaveChanges();
                TempData["StatusMessage"] = "Category deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
