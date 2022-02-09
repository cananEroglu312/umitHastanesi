using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using umitHastanesiWeb.Data;
using umitHastanesiWeb.Models;

namespace umitHastanesiWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public DoctorController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Doctor
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Doctor.Include(d => d.Degree).Include(d => d.Department).Include(d => d.Language);
            return View(await applicationDbContext.ToListAsync());
        }
        // GET: Doctor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Degree)
                .Include(d => d.Department)
                .Include(d => d.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctor/Create
        public IActionResult Create()
        {
            ViewData["DegreeId"] = new SelectList(_context.Degree, "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name");
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name");
            return View();
        }

        // POST: Doctor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DepartmentId,DateOfBirth,Gender,DegreeId,LanguageId,Education,Experience,Image")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {

                //******
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\doctor");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                doctor.Image = @"\images\doctor\" + fileName + extension;

                //********

                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeId"] = new SelectList(_context.Degree, "Id", "Name", doctor.DegreeId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", doctor.DepartmentId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name", doctor.LanguageId);
            return View(doctor);
        }

        // GET: Doctor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            ViewData["DegreeId"] = new SelectList(_context.Degree, "Id", "Name", doctor.DegreeId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", doctor.DepartmentId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name", doctor.LanguageId);
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DepartmentId,DateOfBirth,Gender,DegreeId,LanguageId,Education,Experience,Image")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DegreeId"] = new SelectList(_context.Degree, "Id", "Name", doctor.DegreeId);
            ViewData["DepartmentId"] = new SelectList(_context.Department, "Id", "Name", doctor.DepartmentId);
            ViewData["LanguageId"] = new SelectList(_context.Language, "Id", "Name", doctor.LanguageId);
            return View(doctor);
        }

        // GET: Doctor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .Include(d => d.Degree)
                .Include(d => d.Department)
                .Include(d => d.Language)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctor.FindAsync(id);
            _context.Doctor.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctor.Any(e => e.Id == id);
        }
    }
}
