using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebHotelGranChaco.Data;
using WebHotelGranChaco.Models;

namespace WebHotelGranChaco.Controllers
{
    public class HabitacionController : Controller
    {
        private readonly WebDbContext _context;

        public HabitacionController(WebDbContext context)
        {
            _context = context;
        }

        // GET: Habitacion
        public async Task<IActionResult> Index()
        {
            var webDbContext = _context.Habitaciones.Include(h => h.TipoHabitacion);
            return View(await webDbContext.ToListAsync());
        }

        // GET: Habitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitaciones
                .Include(h => h.TipoHabitacion)
                .FirstOrDefaultAsync(m => m.Id_Habitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // GET: Habitacion/Create
        public IActionResult Create()
        {
            ViewData["IdTipoHabitacion"] = new SelectList(_context.Tipos, "Id_Tipo", "CapacidadMaxima");
            return View();
        }

        // POST: Habitacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Habitacion,NumeroHabitacion,PrecioPorNoche,Descripcion,Imagen,Estado,FechaLimpieza,IdTipoHabitacion")] Habitacion habitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.Tipos, "Id_Tipo", "CapacidadMaxima", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }
            ViewData["IdTipoHabitacion"] = new SelectList(_context.Tipos, "Id_Tipo", "CapacidadMaxima", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // POST: Habitacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Habitacion,NumeroHabitacion,PrecioPorNoche,Descripcion,Imagen,Estado,FechaLimpieza,IdTipoHabitacion")] Habitacion habitacion)
        {
            if (id != habitacion.Id_Habitacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacionExists(habitacion.Id_Habitacion))
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
            ViewData["IdTipoHabitacion"] = new SelectList(_context.Tipos, "Id_Tipo", "CapacidadMaxima", habitacion.IdTipoHabitacion);
            return View(habitacion);
        }

        // GET: Habitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitaciones == null)
            {
                return NotFound();
            }

            var habitacion = await _context.Habitaciones
                .Include(h => h.TipoHabitacion)
                .FirstOrDefaultAsync(m => m.Id_Habitacion == id);
            if (habitacion == null)
            {
                return NotFound();
            }

            return View(habitacion);
        }

        // POST: Habitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitaciones == null)
            {
                return Problem("Entity set 'WebDbContext.Habitaciones'  is null.");
            }
            var habitacion = await _context.Habitaciones.FindAsync(id);
            if (habitacion != null)
            {
                _context.Habitaciones.Remove(habitacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacionExists(int id)
        {
          return _context.Habitaciones.Any(e => e.Id_Habitacion == id);
        }
    }
}
