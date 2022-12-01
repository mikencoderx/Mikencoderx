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
        private readonly AppContext _Context;
        SqlConnection connect = new SqlConnection("Data Source =DESKTOP-P1P9ODQ;initial catalog = Mikencoderx; integrated security = true; Trusted_Connection=True;");
        public MembresiasController(AppContext context)
        {
            _Context = context;
        }
        

        public IActionResult Index()
        {
           var membresia = _Context.Membresias.ToList();
            
            return View(membresia);
        }

        public IActionResult Crear()
        {
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
