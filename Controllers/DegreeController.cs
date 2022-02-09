using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using umitHastanesiWeb.Data;
using umitHastanesiWeb.Models;

namespace umitHastanesiWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DegreeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DegreeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Degree
        public async Task<IActionResult> Index()
        {
            return View(await _context.Degree.ToListAsync());
        }

        // GET: Degree/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degree
                .FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // GET: Degree/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Degree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Degree degree)
        {
            if (ModelState.IsValid)
            {
                _context.Add(degree);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(degree);
        }

        // GET: Degree/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degree.FindAsync(id);
            if (degree == null)
            {
                return NotFound();
            }
            return View(degree);
        }

        // POST: Degree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Degree degree)
        {
            if (id != degree.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(degree);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DegreeExists(degree.Id))
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
            return View(degree);
        }

        // GET: Degree/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var degree = await _context.Degree
                .FirstOrDefaultAsync(m => m.Id == id);
            if (degree == null)
            {
                return NotFound();
            }

            return View(degree);
        }

        // POST: Degree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var degree = await _context.Degree.FindAsync(id);
            _context.Degree.Remove(degree);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DegreeExists(int id)
        {
            return _context.Degree.Any(e => e.Id == id);
        }
    }
}
