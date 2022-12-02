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
        private readonly AppContext _Context;
        public MembresiasController(AppContext context, IHttpContextAccessor acess)
        {
            _Context = context;
            _Acess = acess;
        }


        public async Task <IActionResult> Index()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            
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

                membresia.Clientes.Nombre = request.Clientes.Nombre;
                membresia.Proyectos.Nombre = request.Proyectos.Nombre;
                membresia.Planes.Tipo = request.Planes.Tipo;
                membresia.FechaApertura = request.FechaApertura;
                membresia.FechaVencimiento = request.FechaVencimiento;

                _Context.Entry(membresia).State = EntityState.Modified;
                await _Context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
