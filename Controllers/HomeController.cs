using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using umitHastanesiWeb.Data;
using umitHastanesiWeb.Models;

namespace umitHastanesiWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        //PANEL
        public IActionResult Panel()
        {
            return View();
        }
        //INDEX   
        public IActionResult Index()
        {
            return View();
        }
        //KURUMSAL
        public IActionResult PatientRights()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult VisitorRights()
        {
            return View();
        }
        //BÖLÜMLER
        public IActionResult Brain()
        {
            return View();
        }
        public IActionResult CheckUp()
        {
            return View();
        }
        public IActionResult Child()
        {
            return View();
        }
        public IActionResult Dermatology()
        {
            return View();
        }
        public IActionResult Emergency()
        {
            return View();
        }
        public IActionResult Eyes()
        {
            return View();
        }
        public IActionResult GeneralSurgery()
        {
            return View();
        }
        public IActionResult InternalMedicine()
        {
            return View();
        }
        public IActionResult Neurology()
        {
            return View();
        }
        public IActionResult Otolaryngology()
        {
            return View();
        }
        //HEKİMLERİMİZ
        public async Task<IActionResult> Doctors()
        {
            var applicationDbContext = _context.Doctor.Include(d => d.Degree).Include(d => d.Department).Include(d => d.Language);
            return View(await applicationDbContext.ToListAsync());
        }

        [Authorize]
        //RANDEVU
        public async Task<IActionResult> Appointment()
        {
            var applicationDbContext = _context.Appointment.Include(a => a.Doctor);
            return View(await applicationDbContext.ToListAsync());
        }
        //İLETİŞİM
        public IActionResult Contact()
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
