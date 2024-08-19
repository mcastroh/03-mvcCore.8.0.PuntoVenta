using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPuntoVenta.Data.Context;
using WebPuntoVenta.Data.Models;

namespace WebPuntoVenta.Controllers
{
    public class Ocasiones_Version_01Controller : Controller
    {
        private readonly AppDbContext _context;

        public Ocasiones_Version_01Controller(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ocasiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ocasiones.ToListAsync());
        }

        // GET: Ocasiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var ocasiones = await _context.Ocasiones.FirstOrDefaultAsync(m => m.Id == id);

            if (ocasiones == null)
                return NotFound();

            return View(ocasiones);
        }

        // GET: Ocasiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocasiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ocasion")] Ocasiones ocasiones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocasiones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(ocasiones);
        }

        // GET: Ocasiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var ocasiones = await _context.Ocasiones.FindAsync(id);

            if (ocasiones == null)
                return NotFound();

            return View(ocasiones);
        }

        // POST: Ocasiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ocasion")] Ocasiones ocasiones)
        {
            if (id != ocasiones.Id)
                return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocasiones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcasionesExists(ocasiones.Id))
                        return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ocasiones);
        }

        // GET: Ocasiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var ocasiones = await _context.Ocasiones.FirstOrDefaultAsync(m => m.Id == id);

            if (ocasiones == null)
                return NotFound();

            return View(ocasiones);
        }

        // POST: Ocasiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocasiones = await _context.Ocasiones.FindAsync(id);

            if (ocasiones != null)
                _context.Ocasiones.Remove(ocasiones);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcasionesExists(int id)
        {
            return _context.Ocasiones.Any(e => e.Id == id);
        }

    }
}