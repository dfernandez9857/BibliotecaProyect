using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DetallePrestamoesController : Controller
    {
        private readonly MVCbibliotecaContext _context;

        public DetallePrestamoesController(MVCbibliotecaContext context)
        {
            _context = context;
        }

        // GET: DetallePrestamoes
        public async Task<IActionResult> Index()
        {
            var mVCbibliotecaContext = _context.DetallePrestamos.Include(d => d.IdEstadoDetalleNavigation).Include(d => d.IdLibroNavigation).Include(d => d.IdPrestamoNavigation);
            return View(await mVCbibliotecaContext.ToListAsync());
        }

        // GET: DetallePrestamoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetallePrestamos == null)
            {
                return NotFound();
            }

            var detallePrestamo = await _context.DetallePrestamos
                .Include(d => d.IdEstadoDetalleNavigation)
                .Include(d => d.IdLibroNavigation)
                .Include(d => d.IdPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (detallePrestamo == null)
            {
                return NotFound();
            }

            return View(detallePrestamo);
        }

        // GET: DetallePrestamoes/Create
        public IActionResult Create()
        {
            ViewData["IdEstadoDetalle"] = new SelectList(_context.EstadoDetalles, "Id", "Id");
            ViewData["IdLibro"] = new SelectList(_context.Libros, "Id", "Id");
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Id", "Id");
            return View();
        }

        // POST: DetallePrestamoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPrestamo,IdLibro,Observacion,IdEstadoDetalle,Fecha")] DetallePrestamo detallePrestamo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePrestamo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadoDetalle"] = new SelectList(_context.EstadoDetalles, "Id", "Id", detallePrestamo.IdEstadoDetalle);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "Id", "Id", detallePrestamo.IdLibro);
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Id", "Id", detallePrestamo.IdPrestamo);
            return View(detallePrestamo);
        }

        // GET: DetallePrestamoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetallePrestamos == null)
            {
                return NotFound();
            }

            var detallePrestamo = await _context.DetallePrestamos.FindAsync(id);
            if (detallePrestamo == null)
            {
                return NotFound();
            }
            ViewData["IdEstadoDetalle"] = new SelectList(_context.EstadoDetalles, "Id", "Id", detallePrestamo.IdEstadoDetalle);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "Id", "Id", detallePrestamo.IdLibro);
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Id", "Id", detallePrestamo.IdPrestamo);
            return View(detallePrestamo);
        }

        // POST: DetallePrestamoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPrestamo,IdLibro,Observacion,IdEstadoDetalle,Fecha")] DetallePrestamo detallePrestamo)
        {
            if (id != detallePrestamo.IdPrestamo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePrestamo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePrestamoExists(detallePrestamo.IdPrestamo))
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
            ViewData["IdEstadoDetalle"] = new SelectList(_context.EstadoDetalles, "Id", "Id", detallePrestamo.IdEstadoDetalle);
            ViewData["IdLibro"] = new SelectList(_context.Libros, "Id", "Id", detallePrestamo.IdLibro);
            ViewData["IdPrestamo"] = new SelectList(_context.Prestamos, "Id", "Id", detallePrestamo.IdPrestamo);
            return View(detallePrestamo);
        }

        // GET: DetallePrestamoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetallePrestamos == null)
            {
                return NotFound();
            }

            var detallePrestamo = await _context.DetallePrestamos
                .Include(d => d.IdEstadoDetalleNavigation)
                .Include(d => d.IdLibroNavigation)
                .Include(d => d.IdPrestamoNavigation)
                .FirstOrDefaultAsync(m => m.IdPrestamo == id);
            if (detallePrestamo == null)
            {
                return NotFound();
            }

            return View(detallePrestamo);
        }

        // POST: DetallePrestamoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetallePrestamos == null)
            {
                return Problem("Entity set 'MVCbibliotecaContext.DetallePrestamos'  is null.");
            }
            var detallePrestamo = await _context.DetallePrestamos.FindAsync(id);
            if (detallePrestamo != null)
            {
                _context.DetallePrestamos.Remove(detallePrestamo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePrestamoExists(int id)
        {
          return (_context.DetallePrestamos?.Any(e => e.IdPrestamo == id)).GetValueOrDefault();
        }
    }
}
