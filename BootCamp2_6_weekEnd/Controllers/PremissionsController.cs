using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BootCamp2_6_weekEnd.Data;
using BootCamp2_6_weekEnd.Models;

namespace BootCamp2_6_weekEnd.Controllers
{
    public class PremissionsController : Controller
    {
        private readonly AppDbContext _context;

        public PremissionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Premissions
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Premissions.Include(p => p.Employee);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Premissions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premission = await _context.Premissions
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premission == null)
            {
                return NotFound();
            }

            return View(premission);
        }

        // GET: Premissions/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: Premissions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ISCategory,ISProduct,ISCustomer,ISEmployee,ISOrder,ISOrderDetails,EmployeeId")] Premission premission)
        {
            if (ModelState.IsValid)
            {
                _context.Add(premission);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", premission.EmployeeId);
            return View(premission);
        }

        // GET: Premissions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premission = await _context.Premissions.FindAsync(id);
            if (premission == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", premission.EmployeeId);
            return View(premission);
        }

        // POST: Premissions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ISCategory,ISProduct,ISCustomer,ISEmployee,ISOrder,ISOrderDetails,EmployeeId")] Premission premission)
        {
            if (id != premission.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(premission);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PremissionExists(premission.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", premission.EmployeeId);
            return View(premission);
        }

        // GET: Premissions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var premission = await _context.Premissions
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (premission == null)
            {
                return NotFound();
            }

            return View(premission);
        }

        // POST: Premissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var premission = await _context.Premissions.FindAsync(id);
            if (premission != null)
            {
                _context.Premissions.Remove(premission);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PremissionExists(int id)
        {
            return _context.Premissions.Any(e => e.Id == id);
        }
    }
}
