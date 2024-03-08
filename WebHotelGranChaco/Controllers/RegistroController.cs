using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebHotelGranChaco.Data;
using WebHotelGranChaco.Dtos;
using WebHotelGranChaco.Models;

namespace WebHotelGranChaco.Controllers
{
    public class RegistroController : Controller
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;

        public RegistroController(WebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Registro
        public async Task<IActionResult> Index()
        {
            var registros = await _context.Registros
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Include(r => r.Usuario)
                .ToListAsync();

            var registrosDto = _mapper.Map<List<DtoRegistro>>(registros);

            return View(registrosDto);
        }

        // GET: Registro/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id_Registro == id);

            if (registro == null)
            {
                return NotFound();
            }

            var registroDto = _mapper.Map<DtoRegistro>(registro);

            return View(registroDto);
        }

        // GET: Registro/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Telefono");
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "Id_Habitacion", "NumeroHabitacion"); // Asegúrate de que estás usando "NumeroHabitacion" en lugar de "NumeroDeHabitacion"
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id_Usuario", "CorreoElectronico");
            return View();
        }

        // POST: Registro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Registro,FechaRegistro,FechaSalida,NumeroHabitacion,NumeroHuspedes,Noches,Estado,PrecioTotal,IdCliente,IdHabitacion,IdUsuario")] DtoRegistro registroDto)
        {
            if (ModelState.IsValid)
            {
                var registro = _mapper.Map<Registro>(registroDto);
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Telefono", registroDto.IdCliente);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "Id_Habitacion", "NumeroHabitacion", registroDto.IdHabitacion); // Asegúrate de que estás usando "NumeroHabitacion" en lugar de "NumeroDeHabitacion"
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id_Usuario", "CorreoElectronico", registroDto.IdUsuario);
            return View(registroDto);
        }

        // GET: Registro/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }

            var registroDto = _mapper.Map<DtoRegistro>(registro);

            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Telefono", registro.IdCliente);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "Id_Habitacion", "Estado", registro.IdHabitacion);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id_Usuario", "CorreoElectronico", registro.IdUsuario);

            return View(registroDto);
        }


        // POST: Registro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Registro,FechaRegistro,FechaSalida,NumeroHabitacion,NumeroHuspedes,Noches,Estado,PrecioTotal,IdCliente,IdHabitacion,IdUsuario")] DtoRegistro registroDto)
        {
            if (id != registroDto.Id_Registro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var registro = _mapper.Map<Registro>(registroDto);
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registroDto.Id_Registro))
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
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "Id_Cliente", "Telefono", registroDto.IdCliente);
            ViewData["IdHabitacion"] = new SelectList(_context.Habitaciones, "Id_Habitacion", "Estado", registroDto.IdHabitacion);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "Id_Usuario", "CorreoElectronico", registroDto.IdUsuario);
            return View(registroDto);
        }

        // GET: Registro/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registro = await _context.Registros
                .Include(r => r.Cliente)
                .Include(r => r.Habitacion)
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.Id_Registro == id);
            if (registro == null)
            {
                return NotFound();
            }

            var registroDto = _mapper.Map<DtoRegistro>(registro);

            return View(registroDto);
        }

        // POST: Registro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registro = await _context.Registros.FindAsync(id);
            if (registro != null)
            {
                _context.Registros.Remove(registro);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.Id_Registro == id);
        }
    }
}
