using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DAL;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext _context { get; }

        public async Task <IActionResult> Index()
        {
            HomeVm Homevm = new HomeVm
            {
                Cars = await _context.Cars.Include(x=>x.Category).ToListAsync(),
                Categories= await _context.Categories.ToListAsync(),
            };
            return View(Homevm);
        }

    }
}
