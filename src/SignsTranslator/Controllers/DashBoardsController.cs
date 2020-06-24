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
    public class DashBoardsController : Controller
    {
        private readonly SignsContext _context;

        public DashBoardsController(SignsContext context)
        {
            _context = context;
        }

        // GET: DashBoards
        public async Task<IActionResult> Index()
        {
            return View(await _context.DashBoard.ToListAsync());
        }

        // GET: DashBoards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashBoard = await _context.DashBoard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dashBoard == null)
            {
                return NotFound();
            }

            return View(dashBoard);
        }

        // GET: DashBoards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DashBoards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,AdminName,Password")] DashBoard dashBoard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dashBoard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dashBoard);
        }

        // GET: DashBoards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashBoard = await _context.DashBoard.FindAsync(id);
            if (dashBoard == null)
            {
                return NotFound();
            }
            return View(dashBoard);
        }

        // POST: DashBoards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,AdminName,Password")] DashBoard dashBoard)
        {
            if (id != dashBoard.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dashBoard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DashBoardExists(dashBoard.ID))
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
            return View(dashBoard);
        }

        // GET: DashBoards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dashBoard = await _context.DashBoard
                .FirstOrDefaultAsync(m => m.ID == id);
            if (dashBoard == null)
            {
                return NotFound();
            }

            return View(dashBoard);
        }

        // POST: DashBoards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dashBoard = await _context.DashBoard.FindAsync(id);
            _context.DashBoard.Remove(dashBoard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DashBoardExists(int id)
        {
            return _context.DashBoard.Any(e => e.ID == id);
        }
    }
}
