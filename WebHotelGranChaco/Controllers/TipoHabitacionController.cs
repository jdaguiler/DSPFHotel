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
    public class TipoHabitacionController : Controller
    {
        private readonly WebDbContext _context;

        public TipoHabitacionController(WebDbContext context)
        {
            _context = context;
        }

        // GET: TipoHabitacion
        public async Task<IActionResult> Index()
        {
              return View(await _context.Tipos.ToListAsync());
        }

        // GET: TipoHabitacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.Tipos
                .FirstOrDefaultAsync(m => m.Id_Tipo == id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
        }

        // GET: TipoHabitacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoHabitacion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Tipo,NombreTipo,CapacidadMaxima,PrecioBase,Descripcion")] TipoHabitacion tipoHabitacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoHabitacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoHabitacion);
        }

        // GET: TipoHabitacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.Tipos.FindAsync(id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }
            return View(tipoHabitacion);
        }

        // POST: TipoHabitacion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Tipo,NombreTipo,CapacidadMaxima,PrecioBase,Descripcion")] TipoHabitacion tipoHabitacion)
        {
            if (id != tipoHabitacion.Id_Tipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoHabitacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoHabitacionExists(tipoHabitacion.Id_Tipo))
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
            return View(tipoHabitacion);
        }

        // GET: TipoHabitacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tipos == null)
            {
                return NotFound();
            }

            var tipoHabitacion = await _context.Tipos
                .FirstOrDefaultAsync(m => m.Id_Tipo == id);
            if (tipoHabitacion == null)
            {
                return NotFound();
            }

            return View(tipoHabitacion);
        }

        // POST: TipoHabitacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tipos == null)
            {
                return Problem("Entity set 'WebDbContext.Tipos'  is null.");
            }
            var tipoHabitacion = await _context.Tipos.FindAsync(id);
            if (tipoHabitacion != null)
            {
                _context.Tipos.Remove(tipoHabitacion);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoHabitacionExists(int id)
        {
          return _context.Tipos.Any(e => e.Id_Tipo == id);
        }
    }
}
