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
        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-P1P9ODQ; initial catalog = Mikencoderx; integrated security = true; Trusted_Connection=True;");
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _context;
        public ProyectosController(AppContext context, IHttpContextAccessor acess)
        {
            _context = context;
            _Acess = acess;
        }

        public void recargar()
        {
            connect.Query("Recargar", new { }, commandType: CommandType.StoredProcedure);
        }

        public async Task<IActionResult> Index()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            recargar();
            var proyectos = await _context.Proyectos.Include(z => z.Programadores).ToListAsync();
            return View(proyectos);
        }

        public IActionResult Crear()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

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
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            if (request != null)
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
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

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
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

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
