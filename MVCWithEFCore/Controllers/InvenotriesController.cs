using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCWithEFCore.Models;

namespace MVCWithEFCore.Controllers
{
    public class InvenotriesController : Controller
    {
        private readonly SmsContext _context;

        public InvenotriesController(SmsContext context)
        {
            _context = context;
        }
        [Route("/Invenotries/Index")]
        // GET: Invenotries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Invenotries.ToListAsync());
        }

        // GET: Invenotries/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invenotry = await _context.Invenotries
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (invenotry == null)
            {
                return NotFound();
            }

            return View(invenotry);
        }

        // GET: Invenotries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Invenotries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProId,ProName,ProSupplier,ProCategory,ProSubCat,ProPricePerItem,ProQuantity,ProOrderPrice")] Invenotry invenotry)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invenotry);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(invenotry);
        }

        // GET: Invenotries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invenotry = await _context.Invenotries.FindAsync(id);
            if (invenotry == null)
            {
                return NotFound();
            }
            return View(invenotry);
        }

        // POST: Invenotries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProId,ProName,ProSupplier,ProCategory,ProSubCat,ProPricePerItem,ProQuantity,ProOrderPrice")] Invenotry invenotry)
        {
            if (id != invenotry.ProId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invenotry);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvenotryExists(invenotry.ProId))
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
            return View(invenotry);
        }

        // GET: Invenotries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invenotry = await _context.Invenotries
                .FirstOrDefaultAsync(m => m.ProId == id);
            if (invenotry == null)
            {
                return NotFound();
            }

            return View(invenotry);
        }

        // POST: Invenotries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invenotry = await _context.Invenotries.FindAsync(id);
            if (invenotry != null)
            {
                _context.Invenotries.Remove(invenotry);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvenotryExists(int id)
        {
            return _context.Invenotries.Any(e => e.ProId == id);
        }
    }
}
