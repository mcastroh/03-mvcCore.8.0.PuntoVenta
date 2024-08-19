using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPuntoVenta.Data.Context;
using WebPuntoVenta.Data.Models;

namespace WebPuntoVenta.Controllers
{
    public class OcasionesController : Controller
    {
        private readonly AppDbContext _context;

        public OcasionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Ocasiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ocasiones.ToListAsync());
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





        private bool OcasionesExists(int id)
        {
            return _context.Ocasiones.Any(e => e.Id == id);
        }


        #region GET: Crear/Editar

        public async Task<IActionResult> Attach(int? id)
        {
            if (id == null)
                return PartialView("Attach", new Ocasiones());

            var ocasiones = await _context.Ocasiones.FindAsync(id);

            if (ocasiones == null)
                return NotFound();

            return PartialView("Attach", ocasiones);
        }

        #endregion

        #region POST: Guardar Crear/Editar

        [HttpPost, ActionName("AttachConfirmed")]
        public async Task<IActionResult> AttachConfirmed([Bind("Id,Ocasion")] Ocasiones Ocasiones)
        {
            try
            {
                if (Ocasiones.Id > 0)
                    _context.Update(Ocasiones);
                else
                    await _context.AddAsync(Ocasiones);

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OcasionesExists(Ocasiones.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Json(Ocasiones);
        }

        #endregion

        #region POST Delete: Ocasiones 

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ocasiones = await _context.Ocasiones.FindAsync(id);

            if (ocasiones != null)
            {
                _context.Ocasiones.Remove(ocasiones);
                await _context.SaveChangesAsync();
                return Ok(ocasiones);
            }

            return StatusCode(404);

        }

        #endregion


    }
}