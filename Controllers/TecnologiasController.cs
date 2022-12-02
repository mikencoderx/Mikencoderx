using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mikencoderx.Models;
using AppContext = Mikencoderx.Context.AppContext;

namespace Mikencoderx.Controllers
{
    public class TecnologiasController : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _context;
        public TecnologiasController(AppContext context, IHttpContextAccessor acess)
        {
            _context = context;
            _Acess = acess;
        }

        public async Task<IActionResult> Index()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar
            var tecnologias = await _context.Tecnologias.ToListAsync();
            return View(tecnologias);
        }

        public async Task<IActionResult> Crear()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearTecnologia(Tecnologias request)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            if (request != null)
            {
                Tecnologias tecnologia = new Tecnologias();
                tecnologia = request;

                _context.Tecnologias.Add(tecnologia);
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

            var tecnologia = _context.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            return View(tecnologia);
        }

        [HttpPost]
        public async Task<IActionResult> EditarTecnologia(Tecnologias request)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            if (request != null)
            {
                Tecnologias tecnologia = _context.Tecnologias.Find(request.PkTecnologias);
                tecnologia.Nombre = request.Nombre;
                tecnologia.URLFoto = request.URLFoto;

                _context.Entry(tecnologia).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            var tecnologia = _context.Tecnologias.Find(id);
            if (tecnologia == null)
            {
                return NotFound();
            }

            _context.Tecnologias.Remove(tecnologia);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
    }
}
