using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Mikencoderx.Models;
using System.Data;
using AppContext = Mikencoderx.Context.AppContext;

namespace Mikencoderx.Controllers
{
    public class ProgramadoresController : Controller
    {
        private readonly AppContext _context;
        public ProgramadoresController(AppContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var programadores = await _context.Programadores.ToListAsync();
            return View(programadores);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Programadores = _context.Programadores.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkPrgramadores.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearProgramador(Programadores request)
        {
            if (request != null)
            {
                Programadores programador = new Programadores();
                programador = request;

                _context.Programadores.Add(programador);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearMembresias(Membresias request)
        {
            if (request != null)
            {
                Membresias programador = new Membresias();
                programador = request;

                _context.Membresias.Add(programador);
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

            var programador = _context.Programadores.Find(id);
            if (programador == null)
            {
                return NotFound();
            }

            return View(programador);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProgramador(Programadores request)
        {
            if (request != null)
            {
                Programadores programador = _context.Programadores.Find(request.PkPrgramadores);
                programador.Nombre = request.Nombre;
                programador.URLFoto = request.URLFoto;
                programador.Correo = request.Correo;
                programador.Descrpcion = request.Descrpcion;
                programador.Estado = false;

                _context.Entry(programador).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> On(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = _context.Programadores.Find(id);
            if (programador == null)
            {
                return NotFound();
            }

            programador.Estado = true;
            _context.Entry(programador).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Off(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var programador = _context.Programadores.Find(id);
            if (programador == null)
            {
                return NotFound();
            }

            programador.Estado = false;
            _context.Entry(programador).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
