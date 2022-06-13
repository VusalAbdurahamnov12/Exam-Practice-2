using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var category = _context.Categories.ToList();  

            return View(category);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {

            Category Category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (Category == null) return NotFound();
            return View(Category);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Category category)
        {
            Category CategoryDB = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if (CategoryDB == null) return NotFound();
            CategoryDB.Name = category.Name;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null) return NotFound();
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
