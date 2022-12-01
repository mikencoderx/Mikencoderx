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
    public class MembresiasController : Controller
    {
        private readonly IHttpContextAccessor _Acess;
        private readonly AppContext _Context;
        public MembresiasController(AppContext context, IHttpContextAccessor acess)
        {
            _Context = context;
            _Acess = acess;
        }


        public IActionResult Index()
        {
            //comprobacion de que el usuario este logeado -|
            if (_Acess.HttpContext.Session.GetString("Rol") == null)
            {
                return Redirect("~/LogginContraller/Index");
            }
            //no eliminar

            var membresia = _Context.Membresias.ToList();
            
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

            if (Request == null)
            {
                Membresias membresia = new Membresias();
                membresia = request;
                membresia.PkMembresias = request.PkMembresias;
                membresia.FkClientes = request.FkClientes;
                membresia.FechaApertura = request.FechaApertura;
                membresia.FechaVencimiento = request.FechaVencimiento;

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

            ViewBag.Planes = _Context.Planes.Where(x=>x.Estado==true).Select(c => new SelectListItem()
            {
                Text = c.Tipo,
                Value = c.PkPlanes.ToString()
            });
            return View(membresias);
        }
    }
}
