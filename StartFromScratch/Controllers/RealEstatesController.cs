using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bruh.Database;
using StartFromScratch.Models;
using NuGet.Packaging.Signing;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using System.Net.Http;

namespace StartFromScratch.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly ApplicationContext _context;

        public RealEstatesController()
        {
            ApplicationContext db = new ApplicationContext();
            _context = db;
        }

        async Task<List<int>> getIds()
        {
            List<int> ids = new List<int>();
            await _context.Buys.ForEachAsync(x => ids.Add(x.Id));
            await _context.Rents.ForEachAsync(x => ids.Add(x.Id));
            return ids;
        }

        async void CheckForRented()
        {
            var rents = _context.Rents.ToList();
            if (rents.Count == 0) return;
            foreach (var item in rents)
            {
                if(DateTime.Compare(item.From, DateTime.Now) >= 0)
                {
                    rents.Remove(item);
                }
            }
            await _context.SaveChangesAsync();
        }

        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> FakeMail()
        {
            MailSender.SendEmail("Test", "Test", User.Identity.Name, DateTime.Now, DateTime.Now.AddDays(4));
            return View("Index", await _context.RealEstates.ToListAsync());
        }

        // GET: RealEstates
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.RealEstates.ToListAsync());
        }

        public async Task<IActionResult> UserIndex()
        {
            CheckForRented();
            var ids = await getIds();
            return View(await _context.RealEstates.Where(x => !ids.Contains(x.Id)).ToListAsync());
        }
        public async Task<IActionResult> MinuVarad()
        {
            var ids = await getIds();
            return View(await _context.RealEstates.Where(x => ids.Contains(x.Id)).ToListAsync());
        }
        public async Task<IActionResult> Detaalid(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }

        // GET: RealEstates/Details/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }public async Task<IActionResult> Rentida(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }
            var rent = new Rent(realEstate, PaymentType.Daily, DateTime.Now, DateTime.Now);
            return View(rent);
        }
        public async Task<IActionResult> Osta(int? id, DateTime meetup)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }
            var buy = new Buy(realEstate, meetup);
            return View(buy);
        }

        // GET: RealEstates/Create
        [Authorize(Policy = "adminOnly")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RealEstates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Policy = "adminOnly")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Address,Area,Cost,ImageLink")] RealEstate realEstate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(realEstate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(realEstate);
        }

        // GET: RealEstates/Edit/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return View(realEstate);
        }

        // POST: RealEstates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,Area,Cost,ImageLink")] RealEstate realEstate)
        {
            if (id != realEstate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(realEstate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RealEstateExists(realEstate.Id))
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
            return View(realEstate);
        }

        // GET: RealEstates/Delete/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RealEstates == null)
            {
                return NotFound();
            }

            var realEstate = await _context.RealEstates
                .FirstOrDefaultAsync(m => m.Id == id);
            if (realEstate == null)
            {
                return NotFound();
            }

            return View(realEstate);
        }

        // POST: RealEstates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RealEstates == null)
            {
                return Problem("Entity set 'ApplicationContext.RealEstates'  is null.");
            }
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate != null)
            {
                _context.RealEstates.Remove(realEstate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost, ActionName("Rentida")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Rentida(int id, int payment, DateTime from, DateTime until)
        {
            if (_context.RealEstates == null)
            {
                return Problem("Entity set 'ApplicationContext.RealEstates'  is null.");
            }
            if(!(DateTime.Compare(from, until) < 0))
            {
                return RedirectToAction(nameof(UserIndex));
            }
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate != null)
            {
                System.Diagnostics.Debug.WriteLine("real estate exists");
                _context.RealEstates.Remove(realEstate);
                Rent r = new(realEstate, (PaymentType)payment, from, until);
                _context.Rents.Add(r);
            }
            MailSender.SendEmail("You've rented a house!",
                $"Congratulations on your newly rented house with an area of: " +
                $"{realEstate.Area} at {realEstate.Address}!", User.Identity.Name, DateTime.Now.AddHours(1), DateTime.Now.AddHours(3));

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserIndex));
        }
        [HttpPost, ActionName("Osta")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Osta(int id, string details, DateTime meetup)
        {
            if (DateTime.Compare(meetup, DateTime.Now) < 0)
            {
                return RedirectToAction(nameof(UserIndex));
            }
            if (_context.RealEstates == null)
            {
                return Problem("Entity set 'ApplicationContext.RealEstates'  is null.");
            }
            var realEstate = await _context.RealEstates.FindAsync(id);
            if (realEstate != null)
            {
                System.Diagnostics.Debug.WriteLine("real estate exists");
                _context.RealEstates.Remove(realEstate);
                Buy b = new(realEstate, meetup);
                _context.Buys.Add(b);
            }
            MailSender.SendEmail("You've bought a house!",
                $"Congratulations on your newly bought house with an area of: " +
                $"{realEstate.Area} at {realEstate.Address}!", User.Identity.Name, DateTime.Now.AddHours(1), DateTime.Now.AddHours(3));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(UserIndex));
        }

        private bool RealEstateExists(int id)
        {
            return _context.RealEstates.Any(e => e.Id == id);
        }
    }
}
