using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Mikencoderx.Models;
using AppContext = Mikencoderx.Context.AppContext;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Cryptography.X509Certificates;

namespace Mikencoderx.Controllers
{
    public class MembresiasController : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        SqlConnection connect = new SqlConnection("Data Source = DESKTOP-RLKCHTG; initial catalog = Mikencoderx; integrated security = true; Trusted_Connection=True;");
        private readonly AppContext _Context;
        public MembresiasController(AppContext context, IHttpContextAccessor acess)
        {
            _Context = context;
            _Acess = acess;
        }

        public void recargar()
        {
            connect.Query("Recargar", new { }, commandType: CommandType.StoredProcedure);
        }

        public async Task <IActionResult> Index()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar
            recargar();
            if (TempData["sms"] != null)
            {
                ViewBag.sms = TempData["sms"].ToString();
            }

            var membresia = await _Context.Membresias
                .Include(x =>x.Clientes)
                .Include(x => x.Proyectos)
                .Include(x => x.Planes)                
                .ToListAsync();
            return View(membresia);
        }

        public IActionResult Crear()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar
            ViewBag.Clientes = _Context.Clientes.Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.PkCliente.ToString()
            });

            ViewBag.Proyectos = _Context.Proyectos.Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.PkProyecto.ToString()
            });

            ViewBag.Planes = _Context.Planes.Where(x => x.Estado == true).Select(c => new SelectListItem()
            {
                Text = c.Tipo,
                Value = c.PkPlanes.ToString()
            });
            return View();
               
        }

        [HttpPost]
        public async Task<IActionResult> CrearMembresias (Membresias request)
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            if (request != null)
            {
                Membresias membresia = new Membresias();
                membresia = request;
                membresia.FechaApertura = DateTime.Now;

                var plan = _Context.Planes.Where(x => x.PkPlanes == membresia.FkPlanes).FirstOrDefault();

                membresia.FechaVencimiento = DateTime.Now.AddDays(plan.dias);
                var proyecto = _Context.Proyectos.Where(x=>x.PkProyecto == membresia.FkProyecto).FirstOrDefault();
                if(proyecto.Estado == true)
                {
                    TempData["sms"] = "No se puede agregar una membresia a " +proyecto.Nombre+" por que actualmente ya tiene una activa";
                    ViewBag.sms = TempData["sms"];
                    return RedirectToAction(nameof(Index));
                }
               _Context.Membresias.Add(membresia);
                await _Context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        [HttpGet]
        public IActionResult Editar (int? id ) 
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

            var membresias = _Context.Membresias.Find(id);
            if (membresias ==null)
            {
                return NotFound();
            }

            ViewBag.Clientes = _Context.Clientes.Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.PkCliente.ToString()
            });

            ViewBag.Proyectos = _Context.Proyectos.Select(c => new SelectListItem()
            {
                Text = c.Nombre,
                Value = c.PkProyecto.ToString()
            });

            ViewBag.Planes = _Context.Planes.Where(x => x.Estado == true).Select(c => new SelectListItem()
            {
                Text = c.Tipo,
                Value = c.PkPlanes.ToString()
            });
            return View(membresias);


        }

        [HttpPost]
        public async Task <IActionResult> EditarMembresias (Membresias request)
        {
            if(request != null)
            {
                Membresias membresia = _Context.Membresias.Find(request.PkMembresias);

                membresia.FkClientes = request.FkClientes;
                membresia.FkProyecto = request.FkProyecto;
                membresia.FkPlanes = request.FkPlanes;
                membresia.FechaApertura = request.FechaApertura;
                var plan = _Context.Planes.Where(x => x.PkPlanes == membresia.FkPlanes).FirstOrDefault();
                membresia.FechaVencimiento = membresia.FechaApertura.AddDays(plan.dias);

                _Context.Entry(membresia).State = EntityState.Modified;
                await _Context.SaveChangesAsync();

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

            var membresia = _Context.Membresias.Find(id);
            if (membresia == null)
            {
                return NotFound();
            }
            _Context.Membresias.Remove(membresia);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
