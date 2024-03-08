using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHotelGranChaco.Data;
using WebHotelGranChaco.Dtos;
using WebHotelGranChaco.Models;

namespace WebHotelGranChaco.Controllers
{
    public class ClientesController : Controller
    {
        private readonly WebDbContext _context;
        private readonly IMapper _mapper;

        public ClientesController(WebDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.Include(c => c.Natural).ToListAsync();
            var clientesDto = _mapper.Map<List<DtoCliente>>(clientes);
            return View(clientesDto);
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.Include(c => c.Natural).FirstOrDefaultAsync(c => c.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<DtoCliente>(cliente);
            return View(clienteDto);
        }
        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DtoCliente clienteDto)
        {
            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<Cliente>(clienteDto);
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
               
            }
            return RedirectToAction("Create", "Registro");
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.Include(c => c.Natural).FirstOrDefaultAsync(c => c.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<DtoCliente>(cliente);
            return View(clienteDto);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DtoCliente clienteDto)
        {
            if (id != clienteDto.Id_Cliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Cargar el cliente con su entidad relacionada Natural
                    var cliente = await _context.Clientes.Include(c => c.Natural).FirstOrDefaultAsync(c => c.Id_Cliente == id);

                    if (cliente == null)
                    {
                        return NotFound();
                    }

                    // Mapear los datos del DTO al cliente existente
                    _mapper.Map(clienteDto, cliente);

                    // Actualizar el cliente
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(clienteDto.Id_Cliente))
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
            return View(clienteDto);
        }


        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.Include(c => c.Natural).FirstOrDefaultAsync(c => c.Id_Cliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            var clienteDto = _mapper.Map<DtoCliente>(cliente);
            return View(clienteDto);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ClienteExists(int id)
        {
            return _context.Naturales.Any(e => e.Id_Natural == id);
        }
    }
}
