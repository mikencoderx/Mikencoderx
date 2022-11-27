using Microsoft.AspNetCore.Mvc;
using Mikencoderx.Models;
using AppContext = Mikencoderx.Context.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mikencoderx.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppContext _context;
        public ClientesController(AppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearCliente(Clientes request)
        {
            if (request != null)
            {
                Clientes cliente = new Clientes();
                cliente = request;

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _context.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> EditarCliente(Clientes request)
        {
            if (request != null)
            {
                Clientes cliente = _context.Clientes.Find(request.PkCliente);
                cliente.Nombre = request.Nombre;
                cliente.RFC = request.RFC;
                cliente.Telefono = request.Telefono;
                cliente.Correo = request.Correo;

                _context.Entry(cliente).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
