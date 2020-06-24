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
    public class SignsLayoutsController : Controller
    {
        private readonly SignsContext _context;

        public SignsLayoutsController(SignsContext context)
        {
            _context = context;
        }

        // GET: SignsLayouts
        public async Task<IActionResult> Index()
        {
            return View(await _context.SignsLayouts.ToListAsync());
        }

        // GET: SignsLayouts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signsLayouts = await _context.SignsLayouts
                .FirstOrDefaultAsync(m => m.SignId == id);
            if (signsLayouts == null)
            {
                return NotFound();
            }

            return View(signsLayouts);
        }

        // GET: SignsLayouts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SignsLayouts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SignId,LayoutId,PDFDefinition,ImageThumbnail")] SignsLayouts signsLayouts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(signsLayouts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signsLayouts);
        }

        // GET: SignsLayouts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signsLayouts = await _context.SignsLayouts.FindAsync(id);
            if (signsLayouts == null)
            {
                return NotFound();
            }
            return View(signsLayouts);
        }

        // POST: SignsLayouts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SignId,LayoutId,PDFDefinition,ImageThumbnail")] SignsLayouts signsLayouts)
        {
            if (id != signsLayouts.SignId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(signsLayouts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignsLayoutsExists(signsLayouts.SignId))
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
            return View(signsLayouts);
        }

        // GET: SignsLayouts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signsLayouts = await _context.SignsLayouts
                .FirstOrDefaultAsync(m => m.SignId == id);
            if (signsLayouts == null)
            {
                return NotFound();
            }

            return View(signsLayouts);
        }

        // POST: SignsLayouts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signsLayouts = await _context.SignsLayouts.FindAsync(id);
            _context.SignsLayouts.Remove(signsLayouts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SignsLayoutsExists(int id)
        {
            return _context.SignsLayouts.Any(e => e.SignId == id);
        }
    }
}
