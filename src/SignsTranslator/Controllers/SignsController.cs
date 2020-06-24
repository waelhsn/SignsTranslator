using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SignsTranslator.Models;

namespace SignsTranslator.Controllers
{
    public class SignsController : Controller
    {
        private readonly SignsContext _context;

        public SignsController(SignsContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.AllSigns.ToListAsync());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Signs());
            else
                return View(_context.AllSigns.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("SignId,Swedish,English,Russian,Arabic")] Signs signs)
        {
            if (ModelState.IsValid)
            {
                if (signs.SignId == 0)
                    _context.Add(signs);
                else
                    _context.Update(signs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(signs);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var sign = await _context.AllSigns.FindAsync(id);
            _context.AllSigns.Remove(sign);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}

