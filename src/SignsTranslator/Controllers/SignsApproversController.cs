using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SignsTranslator.Models;

namespace SignsTranslator.Controllers
{
    public class SignsApproversController : Controller
    {
        private readonly SignsContext _context;

        public SignsApproversController(SignsContext context)
        {
            _context = context;
        }

        // GET: SignsApprovers
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignsApprovers.ToListAsync());
        }

        // GET: SignsApprovers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signsApprovers = await _context.SignsApprovers
                .FirstOrDefaultAsync(m => m.ApproverID == id);
            if (signsApprovers == null)
            {
                return NotFound();
            }

            return View(signsApprovers);
        }

        // GET: SignsApprovers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignsApprovers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApproverID,ApproverName,Password")] SignsApprovers signsApprovers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signsApprovers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signsApprovers);
        }

        // GET: SignsApprovers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signsApprovers = await _context.SignsApprovers.FindAsync(id);
            if (signsApprovers == null)
            {
                return NotFound();
            }
            return View(signsApprovers);
        }

        // POST: SignsApprovers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApproverID,ApproverName,Password")] SignsApprovers signsApprovers)
        {
            if (id != signsApprovers.ApproverID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signsApprovers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignsApproversExists(signsApprovers.ApproverID))
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
            return View(signsApprovers);
        }

        // GET: SignsApprovers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signsApprovers = await _context.SignsApprovers
                .FirstOrDefaultAsync(m => m.ApproverID == id);
            if (signsApprovers == null)
            {
                return NotFound();
            }

            return View(signsApprovers);
        }

        // POST: SignsApprovers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signsApprovers = await _context.SignsApprovers.FindAsync(id);
            _context.SignsApprovers.Remove(signsApprovers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignsApproversExists(int id)
        {
            return _context.SignsApprovers.Any(e => e.ApproverID == id);
        }
    }
}
