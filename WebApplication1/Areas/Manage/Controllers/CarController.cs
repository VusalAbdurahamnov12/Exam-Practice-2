using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CarController : Controller
    {
        private AppDbContext _context { get; }
        public CarController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeVm homeVm = new HomeVm
            {
                Cars = _context.Cars.ToList(),
                Categories = _context.Categories.ToList(),
            };
            return View(homeVm);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Car car )
        {
            
            _context.Cars.Add(car);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Car cars = _context.Cars.FirstOrDefault(x => x.Id == id);
            if (cars == null) return NotFound();
            _context.Cars.Remove(cars);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
