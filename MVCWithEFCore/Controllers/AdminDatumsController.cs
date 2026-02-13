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
    public class AdminDatumsController : Controller
    {
        private readonly SmsContext _context;

        public AdminDatumsController(SmsContext context)
        {
            _context = context;
        }

        // GET: AdminDatums

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AdminDatum model)
        {
            if (ModelState.IsValid)
            {
                var admin = await _context.AdminData.FirstOrDefaultAsync(a => a.AEmail == model.AEmail && a.APassword == model.APassword);

                if (admin != null)
                {
                    return RedirectToAction("Index", "Invenotries");
                }
                ViewBag.Error = "Invalid email or password.";
            }

            return View(model);
        }


    }
}
