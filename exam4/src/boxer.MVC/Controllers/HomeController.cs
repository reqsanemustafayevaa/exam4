
using boxer.core.Models;
using boxer.data.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace boxer.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
           _context = context;
        }


        public IActionResult Index()
        {
            List<Students>students = _context.Students.ToList();
            return View(students);
        }

       
    }
}
