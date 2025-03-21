using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication2.Models;
using WebApplication2.Models.Data;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        
            private readonly ApplicationDbContext _context;
            public HomeController(ApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IActionResult> Index()
            {
                var products = await _context.Products.ToListAsync();
                return View(products);
            }
        
        private readonly ILogger<HomeController> _logger;

       /* public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
