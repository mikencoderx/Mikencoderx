using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Mikencoderx.Models;
using AppContext = Mikencoderx.Context.AppContext;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mikencoderx.Controllers
{
    public class ProyectosController : Controller
    {
        private readonly AppContext _context;
        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-UG8QV26; initial catalog = Mikencoderx; integrated security = true; Trusted_Connection=True;");
        public ProyectosController(AppContext context)
        {
            _context = context;
        }

        public void recargar()
        {
            connect.Query("Recargar", new { }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IActionResult> Index()
        {
            recargar();
            var proyectos = await _context.Proyectos.Include(z => z.Programadores).ToListAsync();
            return View(proyectos);
        }

        public IActionResult Crear()
        {
            ViewBag.Programadores = _context.Programadores.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkPrgramadores.ToString()
            });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearProyecto (Proyectos request)
        {
            if(request != null)
            {
                Proyectos proyecto = new Proyectos();
                proyecto = request;
                proyecto.Estado = false;

                _context.Proyectos.Add(proyecto);
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

            var proyecto = _context.Proyectos.Find(id);
            if (proyecto == null)
            {
                return NotFound();
            }


            ViewBag.Programadores = _context.Programadores.Select(p => new SelectListItem()
            {
                Text = p.Nombre,
                Value = p.PkPrgramadores.ToString()
            });

            return View(proyecto);
        }

        [HttpPost]
        public async Task<IActionResult> EditarProyecto(Proyectos response)
        {

            Proyectos proyecto = _context.Proyectos.Find(response.PkProyecto);

            proyecto.Nombre = response.Nombre;
            proyecto.URLWeb = response.URLWeb;
            proyecto.URLMaster = response.URLMaster;
            proyecto.FkProgramadores = response.FkProgramadores;

            _context.Entry(proyecto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }
    }
}
