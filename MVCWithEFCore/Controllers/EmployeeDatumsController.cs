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
    public class EmployeeDatumsController : Controller
    {
        private readonly SmsContext _context;

        public EmployeeDatumsController(SmsContext context)
        {
            _context = context;
        }

        // GET: EmployeeDatums
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmployeeData.ToListAsync());
        }

        // GET: EmployeeDatums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDatum = await _context.EmployeeData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDatum == null)
            {
                return NotFound();
            }

            return View(employeeDatum);
        }

        // GET: EmployeeDatums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmployeeDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AImage,EName,EEmail,EPhone,EJobTitle,EJoinDate,ESalary,EShift")] EmployeeDatum employeeDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDatum);
        }

        // GET: EmployeeDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDatum = await _context.EmployeeData.FindAsync(id);
            if (employeeDatum == null)
            {
                return NotFound();
            }
            return View(employeeDatum);
        }

        // POST: EmployeeDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AImage,EName,EEmail,EPhone,EJobTitle,EJoinDate,ESalary,EShift")] EmployeeDatum employeeDatum)
        {
            if (id != employeeDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDatumExists(employeeDatum.Id))
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
            return View(employeeDatum);
        }

        // GET: EmployeeDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeDatum = await _context.EmployeeData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employeeDatum == null)
            {
                return NotFound();
            }

            return View(employeeDatum);
        }

        // POST: EmployeeDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeDatum = await _context.EmployeeData.FindAsync(id);
            if (employeeDatum != null)
            {
                _context.EmployeeData.Remove(employeeDatum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDatumExists(int id)
        {
            return _context.EmployeeData.Any(e => e.Id == id);
        }
    }
}
