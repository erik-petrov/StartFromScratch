using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bruh.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StartFromScratch.Data;
using StartFromScratch.Models;

namespace StartFromScratch.Controllers
{
    public class AgentsController : Controller
    {
        private readonly ApplicationContext _context;

        public AgentsController()
        {
            ApplicationContext db = new ApplicationContext();
            _context = db;
        }

        public async Task<IActionResult> UserIndex()
        {
            return View(await _context.Agents.ToListAsync());
        }
        public async Task<IActionResult> CConsultation(int? id)
        {
            if (id == null || _context.Consultations == null)
            {
                return NotFound();
            }

            var cons = await _context.Consultations.FirstOrDefaultAsync(m => m.Id == id);
            if (cons == null)
            {
                return NotFound();
            }

            return View(cons);
        }

        #region consultations
        // GET: Agents/Delete/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> CDelete(int? id)
        {
            if (id == null || _context.Consultations == null)
            {
                return NotFound();
            }

            var agent = await _context.Consultations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> CDeleteConfirmed(int id)
        {
            if (_context.Agents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Agent'  is null.");
            }
            var agent = await _context.Consultations.FindAsync(id);
            if (agent != null)
            {
                _context.Consultations.Remove(agent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Agents/Details/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> CDetails(int? id)
        {
            if (id == null || _context.Consultations == null)
            {
                return NotFound();
            }

            var agent = await _context.Consultations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        public async Task<IActionResult> ConsultationIndex()
        {
            if ( _context.Consultations == null)
            {
                return NotFound();
            }

            return View(await _context.Consultations.ToListAsync());
        }

        public async Task<IActionResult> ConsultationForm()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConsultationForm([Bind("StartTime, Description, User")] Consultation cons)
        {
            if (ModelState.IsValid)
            {
                if (!(DateTime.Compare(cons.StartTime, DateTime.Now) > 0))
                    return View();

                cons.EndTime = cons.StartTime.AddHours(2);
                _context.Add(cons);
                await _context.SaveChangesAsync();
                MailSender.SendEmail("Teise konsultatsioon aeg", "Tere!\nOleme teadlikuks saanud et sa tahad konsulteerida!\n" +
                "Teie aeg on " + cons.StartTime.ToString("f") + ". Ärge unustage!", User.Identity.Name,
                cons.StartTime,
                cons.EndTime);
            }
            return View("ThankYou");
        }
        #endregion
        // GET: Agents
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Agents.ToListAsync());
        }

        // GET: Agents/Details/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // GET: Agents/Create
        [Authorize(Policy = "adminOnly")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Agents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Create([Bind("Id,FullName,Email,Phone,Password,YearsInField")] Agent agent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        // GET: Agents/Edit/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents.FindAsync(id);
            if (agent == null)
            {
                return NotFound();
            }
            return View(agent);
        }

        // POST: Agents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,Email,Phone,Password,YearsInField")] Agent agent)
        {
            if (id != agent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgentExists(agent.Id))
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
            return View(agent);
        }

        // GET: Agents/Delete/5
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Agents == null)
            {
                return NotFound();
            }

            var agent = await _context.Agents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (agent == null)
            {
                return NotFound();
            }

            return View(agent);
        }

        // POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "adminOnly")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Agents == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Agent'  is null.");
            }
            var agent = await _context.Agents.FindAsync(id);
            if (agent != null)
            {
                _context.Agents.Remove(agent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AgentExists(int id)
        {
            return _context.Agents.Any(e => e.Id == id);
        }
    }
}
