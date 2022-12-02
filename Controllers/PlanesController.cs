using AppContext = Mikencoderx.Context.AppContext;
using Microsoft.AspNetCore.Mvc;
using Mikencoderx.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mikencoderx.Controllers
{
    public class PlanesController : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _context;
        public PlanesController(AppContext context, IHttpContextAccessor acess)
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
            if (TempData.Count() >0)
            {
                if(TempData["sms"] != null)
                {
                    ViewBag.sms = TempData["sms"].ToString();
                }
                if (TempData["alert"] != null)
                {
                    ViewBag.alert = TempData["alert"].ToString();
                }
            }
            var planes = await _context.Planes.ToListAsync();
            return View(planes);
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
        public async Task<IActionResult> CrearPlan(Planes request)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            if (request != null)
            {
                Planes planes = new Planes();
                request.Estado = false;
                planes = request;

                _context.Planes.Add(planes);
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

            var plan = _context.Planes.Find(id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        [HttpPost]
        public async Task<IActionResult> EditarPlan(Planes request)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            if (request != null)
            {
                Planes plan = _context.Planes.Find(request.PkPlanes);
                plan.Tipo = request.Tipo;
                plan.Cantidad = request.Cantidad;
                plan.dias = request.dias;

                var condicion = _context.Membresias.Where(x => x.FkPlanes == plan.PkPlanes).FirstOrDefault();
                if(condicion != null)
                {
                    TempData["alert"] = "No se puede editar "+ plan.Tipo +" puesto que la esta usando una membresia -Elimine la membresia para continuar-";
                    ViewBag.sms = TempData["alert"];

                    return RedirectToAction(nameof(Index));
                }

                _context.Entry(plan).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> On(int? id)
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

            var plan = _context.Planes.Find(id);
            if (plan == null)
            {
                return NotFound();
            }

            plan.Estado = true;
            _context.Entry(plan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Off(int? id)
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

            var plan = _context.Planes.Find(id);
            if (plan == null)
            {
                return NotFound();
            }

            plan.Estado = false;
            _context.Entry(plan).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Eliminar(int? id)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            var plan = _context.Planes.Find(id);
            if (plan == null)
            {
                return NotFound();
            }

            var condicion = _context.Membresias.Where(x => x.FkPlanes == plan.PkPlanes).FirstOrDefault();
            if (condicion == null)
            {
                _context.Planes.Remove(plan);
                _context.SaveChanges();
            }
            else
            {
                TempData["sms"] = "Modifique o elimina los proyectos de " +plan.Tipo+" para poder Eliminarlo";
                ViewBag.sms = TempData["sms"];
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
