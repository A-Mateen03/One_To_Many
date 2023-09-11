using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_CommerceSite.Data;
using E_CommerceSite.Models;

namespace E_CommerceSite.Controllers
{
    public class SizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sizes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sizes.Include(s => s.Products);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sizes == null)
            {
                return NotFound();
            }

            var sizes = await _context.Sizes
                .Include(s => s.Products)
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (sizes == null)
            {
                return NotFound();
            }

            return View(sizes);
        }

        // GET: Sizes/Create
        public IActionResult Create()
        {
            ViewData["P_ID"] = new SelectList(_context.Products, "P_ID", "P_ID");
            return View();
        }

        // POST: Sizes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SizeId,Size,P_ID")] Sizes sizes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sizes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["P_ID"] = new SelectList(_context.Products, "P_ID", "P_ID", sizes.P_ID);
            return View(sizes);
        }

        // GET: Sizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sizes == null)
            {
                return NotFound();
            }

            var sizes = await _context.Sizes.FindAsync(id);
            if (sizes == null)
            {
                return NotFound();
            }
            ViewData["P_ID"] = new SelectList(_context.Products, "P_ID", "P_ID", sizes.P_ID);
            return View(sizes);
        }

        // POST: Sizes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SizeId,Size,P_ID")] Sizes sizes)
        {
            if (id != sizes.SizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sizes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizesExists(sizes.SizeId))
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
            ViewData["P_ID"] = new SelectList(_context.Products, "P_ID", "P_ID", sizes.P_ID);
            return View(sizes);
        }

        // GET: Sizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sizes == null)
            {
                return NotFound();
            }

            var sizes = await _context.Sizes
                .Include(s => s.Products)
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (sizes == null)
            {
                return NotFound();
            }

            return View(sizes);
        }

        // POST: Sizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sizes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Sizes'  is null.");
            }
            var sizes = await _context.Sizes.FindAsync(id);
            if (sizes != null)
            {
                _context.Sizes.Remove(sizes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SizesExists(int id)
        {
          return (_context.Sizes?.Any(e => e.SizeId == id)).GetValueOrDefault();
        }
    }
}
